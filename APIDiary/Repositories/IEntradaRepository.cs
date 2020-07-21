using APIDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDiary.Repositories
{
    public interface IEntradaRepository
    {
        public void AddEntrada(Entrada entrada);
        public void RemoveEntrada(int id);
        public void UpdateEntrada(Entrada entrada);
        public Entrada GetEntradaById(int? id);
        public IEnumerable<Entrada> GetEntradasByDate(int id_user, DateTime data);
        public IEnumerable<Entrada> GetAllEntrada(int id_user);
    }
}
