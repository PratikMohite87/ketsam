using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class CustomerOrderDetails
    {
		public int OrderId { set; get; }
		
		public int CustomerId { set; get; }
		public Customer Customer { set; get; }
		public int TotalPrice { set; get; }
		public ICollection<OrderedProductQuantity> OrderedProductQuantity { set; get; }
	}
}
