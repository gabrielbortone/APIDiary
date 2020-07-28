using System.ComponentModel.DataAnnotations;

namespace APIDiary.Models.ValueType
{
    public class Imagem
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string ImageUrl { get; set; }
        public Entrada Entrada { get; set; }
    }
}
