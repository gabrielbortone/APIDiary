using Microsoft.AspNetCore.Http;

namespace APIDiary.DTOs
{
    public class ImagemDTO
    {
        public IFormFile ImageFile { get; set; }
        public EntradaDTO Entrada { get; set; }
    }
}
