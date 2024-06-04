using Shop.Core.Entities;

namespace Shop.API.Models
{
    public class OrderPostModel
    {
   
        public int ProviderId { get; set; }
        public int SumOrder { get; set; }
        public List<ProductOrderPostModel> Products { get; set; }
    }
}
