using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
    [Table("OrderedProductQuantity")]
    public class OrderedProductQuantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderedProductQuantityId { set; get; }
        [ForeignKey("Product")]
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int Quantity { set; get; }
        [ForeignKey("CustomerOrderDetails")]
        public int OrderId { set; get; } 
        public CustomerOrderDetails CustomerOrderDetails { set; get; }
    }
}
