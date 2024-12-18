using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Dto
{
    public class CreateClientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConnfigurePasswrod { get; set; }

        [Required]
        [Phone]
        public string PhoneNubmer { get; set; }
    }
}
