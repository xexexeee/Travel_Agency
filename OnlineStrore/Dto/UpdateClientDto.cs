using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Dto
{
    public class UpdateClientDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
