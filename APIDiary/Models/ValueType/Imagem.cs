using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDiary.Models.ValueType
{
    public class Imagem
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(250, ErrorMessage = "ImageUrl cannot be longer than 250 characters.")]
        public string ImageUrl { get; set; }

        [NotMapped]
        [DisplayName("Upload file")]
        public IFormFile ImageFile { get; set; }

        [Required]
        public Entrada Entrada { get; set; }
    }
}
