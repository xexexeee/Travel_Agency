using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Storage.MS_SQL
{
    [Index(nameof(Client.Email), IsUnique = true)]
    public class Client
    {
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Name {  get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }    

        public ICollection<Sale> Sales {  get; set; }
    }
}
