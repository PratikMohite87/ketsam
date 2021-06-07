using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class OrderedProductQuantity
    {
        public int OrderedProductQuantityId { set; get; }
        
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int Quantity { set; get; }
        
        public int OrderId { set; get; }
        public CustomerOrderDetails CustomerOrderDetails { set; get; }
    }
}
