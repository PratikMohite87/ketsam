using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
	[Table("CustomerOrderDetails")]
	public class CustomerOrderDetails
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { set; get; }
		[ForeignKey("Customer")]
		public int CustomerId { set; get; }
		public Customer Customer { set; get; }
		public int TotalPrice { set; get; }
		public ICollection<OrderedProductQuantity> OrderedProductQuantity { set; get; }
	}
}