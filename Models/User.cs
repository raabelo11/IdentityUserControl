using Microsoft.AspNetCore.Identity;

namespace IdentityControleDeUsuario.Models
{
    public class User : IdentityUser
    {
        public User() : base() { }
        public DateTime DateOfBirth { get; set; }

    }
}
