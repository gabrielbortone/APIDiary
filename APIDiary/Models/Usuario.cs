using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace APIDiary.Models
{
    public class Usuario : IdentityUser
    {
        public ICollection<Entrada> Entradas { get; set; }
    }
}
