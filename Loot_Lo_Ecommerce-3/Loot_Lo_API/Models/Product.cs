using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Models
{
	[Table("Product")]
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { set; get; }
		[Column(TypeName = "varchar(20)")]
		public string ProductName { set; get; }
		//[Column(TypeName = "varchar(20)")]
		//public string Category { set; get; }
		[Column(TypeName = "numeric(10,2)")]
		public decimal Price { set; get; }
		public int Quantity { set; get; }
		[Column(TypeName = "varchar(100)")]
		public string ImagePath { set; get; }
		[ForeignKey("Admin")]
		public int AdminId { set; get; }
		public Admin Admin { get; set; }
		[ForeignKey("Category")]
		public int CategoryId { set; get; }
		public Category Category { set; get; }
	}
}
