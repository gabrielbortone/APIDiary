using System.ComponentModel.DataAnnotations;

namespace APIDiary.Models
{
    public class LoginUsuarioInfoDto
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
