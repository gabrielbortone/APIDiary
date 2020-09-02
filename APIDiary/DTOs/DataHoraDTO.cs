using System.ComponentModel.DataAnnotations;

namespace APIDiary.DTOs
{
    public class DataHoraDTO
    {
        [Required]
        [Range(0, 23)]
        public int Hour { get; set; }
        [Required]
        [Range(0, 59)]
        public int Minute { get; set; }
    }
}
