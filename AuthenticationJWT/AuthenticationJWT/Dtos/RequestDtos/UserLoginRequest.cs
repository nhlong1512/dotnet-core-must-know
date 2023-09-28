using System.ComponentModel.DataAnnotations;

namespace AuthenticationJWT.Dtos.RequestDtos
{
    public class UserLoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
