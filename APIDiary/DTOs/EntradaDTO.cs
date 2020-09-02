using APIDiary.Models;
using APIDiary.Models.ValueType;
using System;
using System.Collections.Generic;

namespace APIDiary.DTOs
{
    public class EntradaDTO
    {
        public string Titulo { get; set; }
        public DateTime DataEntrada { get; private set; }
        public DataHoraDTO HoraEntrada { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public string Categoria { get; set; }
        public Usuario Usuario { get; set; }
        public List<ImagemDTO> Imagens { get; set; }

        public EntradaDTO()
        {
            DataEntrada = DateTime.Now;
        }
    }
}
