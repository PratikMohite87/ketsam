using Loot_Lo_Client.Helper;
using Loot_Lo_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Controllers
{
    public class CartController : Controller
    {
        List<int> list = new List<int>();

        [HttpGet]
        public async Task<IActionResult> AddToCart(int id)
        {
            int customerId = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;
            Cart cart = new Cart { ProductId = id, CustomerId = customerId, Quantity = 1 };

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(cart);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                var response = await client.PostAsync("/LootLo/Cart", content);

                int categoryId = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "categoryId");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetProductByCategory", "Product", new { id = categoryId});
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return RedirectToAction("GetProductByCategory", "Product", new { id = categoryId });
                }

                return RedirectToAction("GetProductByCategory", "Product", new { id = categoryId });
            }
        }

        public async Task<IActionResult> DisplayCart()
        {
            int id = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                var response = await client.GetAsync("/LootLo/Cart/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<List<Cart>>(readTask);

                    decimal totalAmount = 0;

                    foreach (var item in result)
                    {
                        totalAmount += item.Product.Price * item.Quantity;
                    }

                    ViewBag.totalAmount = totalAmount;

                    return View(result);
                }
                else
                {
                    ViewBag.Message = "No product in cart";
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCartItem(int cartId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                var response = await client.DeleteAsync("/LootLo/Cart/deletecart/" + cartId);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("DisplayCart");
                }

                ViewBag.Message = "Item removal failed";

                return RedirectToAction("DisplayCart");
            }

        }

        public async Task<IActionResult> ClearCart()
        {
            int customerId = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                var response = await client.DeleteAsync("/LootLo/Cart/" + customerId);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("DisplayCart");
                }

                return RedirectToAction("DisplayCart");
            }
        }        
    }
}
