using OnlineStore.Storage.MS_SQL;

namespace OnlineStrore.Dto
{
    public class CreateSaleDto
    {
        public double? TotalSum {  get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
