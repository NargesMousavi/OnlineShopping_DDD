namespace OnlineShopping.BusinessModel
{
    public class ProductDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public decimal Price { get;  set; }
        public bool InStock { get;  set; }
        public string ImageLink { get; set; }
    }
}