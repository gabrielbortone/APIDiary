using APIDiary.Models;
using APIDiary.Models.ValueType;
using System.Collections.Generic;
using System.Linq;

namespace APIDiary.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private readonly AppDbContext _context;
        public ImagemRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddImagem(Imagem imagem)
        {
            _context.Imagens.Add(imagem);
        }

        public IEnumerable<Imagem> GetAllImagem(Entrada entrada)
        {
            return _context.Imagens.Where(i => i.Entrada == entrada).ToList();
        }

        public Imagem GetImagemById(int? id)
        {
            return _context.Imagens.FirstOrDefault(i => i.ImageId == id);
        }

        public void RemoveImagem(int id)
        {
            var imagem = GetImagemById(id);
            _context.Imagens.Remove(imagem);
        }

        public void UpdateImagem(Imagem imagem)
        {
            _context.Imagens.Update(imagem);
        }
    }
}
