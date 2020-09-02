using APIDiary.DTOs;
using APIDiary.Models;
using APIDiary.Repositories.Interfaces;
using APIDiary.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDiary.Controllers
{
    [Authorize(AuthenticationSchemes="Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Usuario> _userManager;
        private readonly ImagemServices _imagemServices;
        private readonly IMapper _mapper;

        public EntradaController(IUnitOfWork unitOfWork, UserManager<Usuario> userManager, 
            ImagemServices imagemServices, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _imagemServices = imagemServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntradas()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var entradas = _unitOfWork.EntradaRepository.GetAllEntrada(usuario.Id).ToList();

            if(usuario == null || entradas == null)
            {
                return NotFound();
            }

            var entradasDTOs = _mapper.Map<List<EntradaDTO>>(entradas);

            return Ok(entradasDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntrada([FromBody]EntradaDTO entradaDto)
        {
            var usuario = await _userManager.GetUserAsync(User);
            entradaDto.Usuario = usuario;
            try
            {
                var entrada = _mapper.Map<Entrada>(entradaDto);
                _unitOfWork.EntradaRepository.AddEntrada(entrada);
                _imagemServices.AddImagens(entrada.Imagens, entrada);
                _unitOfWork.Commit();

                return Ok(entradaDto);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrada(int id,[FromBody] EntradaDTO entradaDto)
        {
            if(id != entradaDto.EntradaId)
            {
                return BadRequest();
            }

            try
            {
                var entrada = _mapper.Map<Entrada>(entradaDto);
                _imagemServices.UpdateImagens(entrada.Imagens, entrada);
                _unitOfWork.EntradaRepository.UpdateEntrada(entrada);
                _unitOfWork.Commit();
                return Ok(entrada);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrada(int id)
        {
            var entrada = _unitOfWork.EntradaRepository.GetEntradaById(id);
            var entradaDto = _mapper.Map<EntradaDTO>(entrada);

            if (entrada == null)
            {
                return NotFound();
            }

            try
            {
                _imagemServices.RemoveImagens(entrada.Imagens, entrada);
                _unitOfWork.EntradaRepository.RemoveEntrada(id);
                _unitOfWork.Commit();
                return Ok(entradaDto);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

    }
}
