using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Dto
{
    public class LoginClientDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
