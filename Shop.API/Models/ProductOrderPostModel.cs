using Shop.Core.Entities;

namespace Shop.API.Models
{
    public class ProductOrderPostModel
    {
       
        public int ProductId { get; set; }
     
        public int Quantity { get; set; }
    }
}
