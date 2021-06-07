using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class Category
    {
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        public ICollection<Product> Products { set; get; }
    }
}
