using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Storage.MS_SQL
{
    public class Sale   
    {
        public Guid Id { get; set; }

        public double TotalSum { get; set; } = 0;

        public DateTime DateTime { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
