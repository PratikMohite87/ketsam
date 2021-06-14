using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class Cart
    {
        public int CartId { set; get; }
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int CustomerId { set; get; }
        public Customer Customer { set; get; }
        public int Quantity { set; get; }
    }
}
