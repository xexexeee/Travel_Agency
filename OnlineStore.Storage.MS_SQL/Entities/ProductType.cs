namespace OnlineStore.Storage.MS_SQL
{
    public class ProductType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
