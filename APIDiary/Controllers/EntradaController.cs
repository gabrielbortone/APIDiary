using APIDiary.Models;
using APIDiary.Models.ValueType;
using APIDiary.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Usuario> _userManager;

        public EntradaController(IUnitOfWork unitOfWork, UserManager<Usuario> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        private void AddImagens(List<Imagem> Imagens, Entrada entrada)
        {
            foreach (Imagem imagem in Imagens)
            {
                imagem.Entrada = entrada;
                _unitOfWork.ImagemRepository.AddImagem(imagem);
            }
        }

        private void UpdateImagens(List<Imagem> Imagens, Entrada entrada)
        {
            foreach (Imagem imagem in Imagens)
            {
                imagem.Entrada = entrada;
                _unitOfWork.ImagemRepository.UpdateImagem(imagem);
            }
        }

        private void RemoveImagens(List<Imagem> Imagens, Entrada entrada)
        {
            foreach (Imagem imagem in Imagens)
            {
                imagem.Entrada = entrada;
                _unitOfWork.ImagemRepository.RemoveImagem(imagem.ImageId);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntradas()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var entradas = _unitOfWork.EntradaRepository.GetAllEntrada(usuario.Id);
            if(entradas == null)
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
                AddImagens(entrada.Imagens, entrada);
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
                UpdateImagens(entrada.Imagens, entrada);
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
                RemoveImagens(entrada.Imagens, entrada);
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
