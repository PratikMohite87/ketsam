using Loot_Lo_Client.Helper;
using Loot_Lo_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> GetProductByCategory(int id)
        {
            if (id == 1)
            {
                ViewBag.Title = "Electronics";
            }
            else
            {
                ViewBag.Title = "Clothing";
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "categoryId", id);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                var response = await client.GetAsync("/LootLo/Product/GetByCategory/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<List<Product>>(readTask);

                    return View(result);
                }
                else 
                {
                    ViewBag.Message = "No product of this category";
                    return View();
                }
            }
        }
    }
}

// hello from 2
