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
    public class OrderController : Controller
    {
        //[HttpPost]
        //public IActionResult ConfirmOrder(IEnumerable<Cart> carts)
        //{
        //    return View(carts);
        //}
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(IList<Cart> carts)
        {
            int customerId = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;

            decimal totalAmount = 0;

            foreach (var item in carts)
            {
                totalAmount += item.Product.Price * item.Quantity;
            }

            List<OrderedProductQuantity> orderedProductQuantities = new List<OrderedProductQuantity>();

            foreach (var item in carts)
            {
                orderedProductQuantities.Add(new OrderedProductQuantity { ProductId = item.ProductId, Quantity = item.Quantity });
            }

            CustomerOrderDetails customerOrderDetails = new CustomerOrderDetails
            {
                CustomerId = customerId,
                TotalPrice = (int)totalAmount,
                OrderedProductQuantity = orderedProductQuantities
            };

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(customerOrderDetails);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                var response = await client.PostAsync("/LootLo/CustomerOrderDetails/addorder", content);

                Customer customer = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer");

                if (response.IsSuccessStatusCode)
                {
                    var response2 = await client.DeleteAsync("/LootLo/Cart/" + customerId);

                    if (response2.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Order Confirmed";
                        ViewBag.TotalAmount = totalAmount;

                        return View(customer);
                    }

                }

                ViewBag.Message = "Order Failed";
                return View(customer);
            }
        }

        public async Task<IActionResult> OrderHistory()
        {
            int customerId = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                var response = await client.GetAsync("/LootLo/CustomerOrderDetails/" + customerId);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<List<CustomerOrderDetails>>(readTask);

                    for (int i = 0; i < result.Count; i++)
                    {
                        var response2 = await client.GetAsync("/LootLo/OrderedProductQuantity/" + result[i].OrderId);

                        if (response2.IsSuccessStatusCode)
                        {
                            var readTask2 = response2.Content.ReadAsStringAsync().Result;
                            var result2 = JsonConvert.DeserializeObject<List<OrderedProductQuantity>>(readTask2);

                            for (int j = 0; j < result2.Count; j++)
                            {
                                var response3 = await client.GetAsync("/LootLo/Product/" + result2[j].ProductId);

                                if (response3.IsSuccessStatusCode)
                                {
                                    var readTask3 = response3.Content.ReadAsStringAsync().Result;
                                    var result3 = JsonConvert.DeserializeObject<Product>(readTask3);

                                    result2[j].Product = result3;
                                }
                            }

                            result[i].OrderedProductQuantity = result2;
                        }
                    }

                    return View(result);
                }

                ViewBag.Message = "No Order Found";
                return View();
            }
        }
    }
}
