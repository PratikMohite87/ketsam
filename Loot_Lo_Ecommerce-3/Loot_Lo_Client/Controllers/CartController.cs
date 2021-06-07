using Loot_Lo_Client.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Controllers
{
    public class CartController : Controller
    {
        List<int> list = new List<int>();

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            list.Add(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", list);

            return RedirectToAction("GetProductByCategory", "Product");
        }

        public IActionResult DisplayCart()
        {
            return View();
        }
    }
}
