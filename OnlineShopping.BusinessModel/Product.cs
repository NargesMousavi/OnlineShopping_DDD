namespace OnlineShopping.BusinessModel
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name{get; private set;}
        public decimal Price { get; private set; }
        public bool InStock { get; private set; }
        public string ImageLink { get; set; }
    }
}