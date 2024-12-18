namespace OnlineStrore.Logic.Queries.Product.GetProductList
{
    public class ProductLookUpDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public uint CountOfProduct { get; set; }
        
        public string ImageUrl { get; set; }
        public string Characteristics { get; set; }

        public string ProductTypeName { get; set; }
    }
}
