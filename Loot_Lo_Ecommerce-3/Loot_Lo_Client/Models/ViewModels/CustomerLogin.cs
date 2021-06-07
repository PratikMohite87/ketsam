using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Models.ViewModels
{
    public class CustomerLogin
    {
        [Required(ErrorMessage = "Required Field")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string CustomerEmail { set; get; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CustomerPassword { set; get; }
    }
}
