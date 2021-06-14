using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class Admin
    {
		public int AdminId { set; get; }
		public string AdminName { set; get; }		
		public string AdminEmail { set; get; }		
		public string AdminPassword { set; get; }
		public ICollection<Product> Products { set; get; }
	}
}
