using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{//יחיד לרבים
    public class Order
    {
        public int Id { get; set; }
        //public int ProductId { get; set; }
        //public int Count {  get; set; }
        public int ProviderId { get; set; }
        public int SumOrder { get; set; }
        public List<ProductOrder> Products { get; set; }
    }
}
