using APIDiary.Models;
using APIDiary.Repositories.Interfaces;
using APIDiary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
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

        public EntradaController(IUnitOfWork unitOfWork, UserManager<Usuario> userManager, ImagemServices imagemServices)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _imagemServices = imagemServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntradas()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var entradas = _unitOfWork.EntradaRepository.GetAllEntrada(usuario.Id);
            if(usuario == null || entradas == null)
            {
                return NotFound();
            }
            return Ok(entradas);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntrada([FromBody]Entrada entrada)
        {
            var usuario = await _userManager.GetUserAsync(User);
            entrada.Usuario = usuario;
            try
            {
                _unitOfWork.EntradaRepository.AddEntrada(entrada);
                _imagemServices.AddImagens(entrada.Imagens, entrada);
                _unitOfWork.Commit();
                return Ok(entrada);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrada(int id,[FromBody] Entrada entrada)
        {
            if(id != entrada.EntradaId)
            {
                return BadRequest();
            }

            try
            {
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
            if (entrada == null)
            {
                return NotFound();
            }

            try
            {
                _imagemServices.RemoveImagens(entrada.Imagens, entrada);
                _unitOfWork.EntradaRepository.RemoveEntrada(id);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

    }
}
