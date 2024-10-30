using System.ComponentModel.DataAnnotations;

namespace IdentityControleDeUsuario.Data.Dto
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
