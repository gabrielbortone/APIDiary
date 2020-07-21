using APIDiary.Models.ValueType;
using System;
using System.Collections.Generic;

namespace APIDiary.Models
{
    public class Entrada
    {
        public int EntradaId { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public string Categoria { get; set; }
        
        public int Id_Usuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Imagem ImagemDestaque { get; set; }

        public IEnumerable<Imagem> Imagens { get; set; }


    }
}
