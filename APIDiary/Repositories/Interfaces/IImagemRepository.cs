using APIDiary.Models;
using APIDiary.Models.ValueType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDiary.Repositories
{
    public interface IImagemRepository
    {
        public void AddImagem(Imagem imagem);
        public void RemoveImagem(int id);
        public void UpdateImagem(Imagem imagem);
        public Imagem GetImagemById(int? id);
        public IEnumerable<Imagem> GetAllImagem(Entrada entrada);
    }
}
