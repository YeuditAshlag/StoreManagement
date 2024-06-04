namespace Shop.API.Models
{
    public class ProductPostModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }//כמות במלאי
    }
}
