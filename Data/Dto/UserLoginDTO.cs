using System.ComponentModel.DataAnnotations;

namespace IdentityUserControl.Data.Dto
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
