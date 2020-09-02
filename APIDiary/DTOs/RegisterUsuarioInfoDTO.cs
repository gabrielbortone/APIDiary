using System.ComponentModel.DataAnnotations;

namespace APIDiary.Models
{
    public class RegisterUsuarioInfoDto
    {
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
