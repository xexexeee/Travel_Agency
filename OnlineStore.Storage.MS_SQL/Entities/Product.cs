using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Storage.MS_SQL
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; } = 0;
        
        public string Characteristics {  get; set; }

        public string ImageUrl { get; set; }

        public uint CountOfProduct { get; set; } = 0;

        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public ICollection<Sale> Sales { get; set; }
        
    }
}
