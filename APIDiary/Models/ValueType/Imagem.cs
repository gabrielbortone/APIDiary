using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDiary.Models.ValueType
{
    public class Imagem
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public Entrada Entrada { get; set; }
        public int EntradaId { get; set; }
    }
}
