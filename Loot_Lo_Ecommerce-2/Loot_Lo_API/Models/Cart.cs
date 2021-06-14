using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { set; get; }
        [ForeignKey("Product")]
        public int ProductId { set; get; }
        public Product Product { set; get; }
        [ForeignKey("Customer")]
        public int CustomerId { set; get; }
        public Customer Customer { set; get; }
        public int Quantity { set; get; }
    }
}
