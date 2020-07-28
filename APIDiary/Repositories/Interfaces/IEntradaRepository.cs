using APIDiary.Models;
using System;
using System.Collections.Generic;

namespace APIDiary.Repositories
{
    public interface IEntradaRepository
    {
        public void AddEntrada(Entrada entrada);
        public void RemoveEntrada(int id);
        public void UpdateEntrada(Entrada entrada);
        public Entrada GetEntradaById(int? id);
        public IEnumerable<Entrada> GetEntradasByDate(string id_user, DateTime data);
        public IEnumerable<Entrada> GetAllEntrada(string id_user);
    }
}
