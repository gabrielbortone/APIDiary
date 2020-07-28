using APIDiary.Models.ValueType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIDiary.Models
{
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Titulo { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataEntrada { get; set; }
        
        [Required]
        [DataType(DataType.Time)]
        public DateTime HoraEntrada { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "DescricaoCurta cannot be longer than 150 characters.")]
        public string DescricaoCurta { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "DescricaoLonga cannot be longer than 50 characters.")]
        public string DescricaoLonga { get; set; }

        [Required]
        [StringLength(30)]
        public string Categoria { get; set; }

        public Usuario Usuario { get; set; }
        public IEnumerable<Imagem> Imagens { get; set; }


    }
}
