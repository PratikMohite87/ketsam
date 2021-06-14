using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class Product
    {
		public int ProductId { set; get; }
		
		public string ProductName { set; get; }
		
		public decimal Price { set; get; }
		public int Quantity { set; get; }
		
		public string ImagePath { set; get; }
		
		public int AdminId { set; get; }
		public Admin Admin { get; set; }
		
		public int CategoryId { set; get; }
		public Category Category { set; get; }
	}
}
