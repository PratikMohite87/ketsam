using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models
{
    public class Customer
    {
		public int CustomerId { set; get; }
		[Required(ErrorMessage = "Required Field")]
		[StringLength(20, ErrorMessage = "Must be between 2 and 20 characters", MinimumLength = 3)]
		[Display(Name = "Full Name")]
		public string CustomerName { set; get; }
		[Required(ErrorMessage = "Required Field")]
		[EmailAddress(ErrorMessage ="Invalid Email Address")]
		[Display(Name = "Email")]
		public string CustomerEmail { set; get; }
		[Required(ErrorMessage = "Required Field")]
		[StringLength(20, ErrorMessage = "Password must be atleast 7 character long and max 20 characters", MinimumLength = 7)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string CustomerPassword { set; get; }
		[Display(Name = "Address")]
		public string CustomerAddress { set; get; }
		[Required(ErrorMessage = "Required Field")]
		[StringLength(10, ErrorMessage = "Invalid phone no", MinimumLength = 10)]
		[Display(Name = "Phone No")]
		public string CustomerPhoneNo { set; get; }
		public ICollection<CustomerOrderDetails> CustomerOrderDetails { set; get; }
	}
}
