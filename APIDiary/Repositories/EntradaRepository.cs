using APIDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIDiary.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly AppDbContext _context;
        public EntradaRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddEntrada(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
        }

        public IEnumerable<Entrada> GetAllEntrada(string id_user)
        {
            return _context.Entradas.Where(e => e.Usuario.Id == id_user).ToList();
        }

        public Entrada GetEntradaById(int? id)
        {
            return _context.Entradas.FirstOrDefault(e => e.EntradaId == id);
        }

        public IEnumerable<Entrada> GetEntradasByDate(string id_user, DateTime data)
        {
            return _context.Entradas.Where(e => e.Usuario.Id == id_user && e.DataEntrada == data).ToList();
        }

        public void RemoveEntrada(int id)
        {
            var entrada = GetEntradaById(id);
            _context.Entradas.Remove(entrada);
        }

        public void UpdateEntrada(Entrada entrada)
        {
            _context.Entradas.Update(entrada);
        }
    }
}
