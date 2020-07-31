using APIDiary.Models;
using APIDiary.Models.ValueType;
using APIDiary.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APIDiary.Services
{
    public class ImagemServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImagemServices(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async void AddImagens(List<Imagem> Imagens, Entrada entrada)
        {
            foreach (Imagem imagem in Imagens)
            {
                imagem.Entrada = entrada;
                imagem.ImageUrl = await UploadImage(imagem);
                _unitOfWork.ImagemRepository.AddImagem(imagem);
            }
        }

        public async void UpdateImagens(List<Imagem> Imagens, Entrada entrada)
        {
            foreach (Imagem imagem in Imagens)
            {
                imagem.Entrada = entrada;
                await DeleteImage(imagem);
                imagem.ImageUrl = await UploadImage(imagem);
                _unitOfWork.ImagemRepository.UpdateImagem(imagem);
            }
        }

        public async void RemoveImagens(List<Imagem> Imagens, Entrada entrada)
        {
            foreach (Imagem imagem in Imagens)
            {
                imagem.Entrada = entrada;
                await DeleteImage(imagem);
                _unitOfWork.ImagemRepository.RemoveImagem(imagem.ImageId);
            }
        }

        private async Task<string> UploadImage(Imagem imagem)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imagem.ImageFile.FileName);
            string extension = Path.GetExtension(imagem.ImageFile.FileName);
            var newFileName = fileName + DateTime.Now.ToString("yyyymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Imagens/", newFileName);

            using (var fileStream = new FileStream(path,FileMode.Create))
            {
                await imagem.ImageFile.CopyToAsync(fileStream);
                return path;
            }

            return "Sem imagem!!!";

        }

        private async Task DeleteImage(Imagem imagem)
        {
            if (System.IO.File.Exists(imagem.ImageUrl))
            {
                System.IO.File.Delete(imagem.ImageUrl);
            }
            else
            {
                throw new IOException("Imagem não encontrada!");
            }

        }

    }
}
