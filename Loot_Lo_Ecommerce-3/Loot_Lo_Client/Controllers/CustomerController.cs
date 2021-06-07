using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Loot_Lo_Client.Helper;
using Loot_Lo_Client.Models;
using Loot_Lo_Client.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Loot_Lo_Client.Controllers
{
    public class CustomerController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["email"] != null)
            {
                return RedirectToAction("Login","Customer",new Customer { CustomerEmail = Request.Cookies["email"] , CustomerPassword = Request.Cookies["password"]});
            }
            return View(new CustomerLogin());
        }

        public async Task<IActionResult> Login(CustomerLogin customerData, bool setCookie = false)
        {
            if (ModelState.IsValid)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44346");
                    client.DefaultRequestHeaders.Clear();
                    string jsonData = JsonConvert.SerializeObject(customerData);
                    var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                    var response = await client.PostAsync("/LootLo/Customer/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<Customer>(readTask);

                        if (setCookie)
                        {
                            CookieOptions options = new CookieOptions();
                            options.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Append("email", result.CustomerEmail, options);
                            Response.Cookies.Append("password", result.CustomerPassword, options);
                        }

                        SessionHelper.SetObjectAsJson(HttpContext.Session, "customer", result);
                        //SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", new List<int>());
                        return RedirectToAction("Index", "Home");

                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }

                return View();
            }

            return View(customerData);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Customer());
        }

        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44346");
                    client.DefaultRequestHeaders.Clear();
                    string jsonData = JsonConvert.SerializeObject(customer);
                    var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                    var response = await client.PostAsync("/LootLo/Customer/register", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<int>(readTask);
                        if (result == 1)
                            return RedirectToAction("Login", "Customer");

                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Message = "Registration Failed";
                    }
                }

                return View(new Customer());
            }

            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                int customerId = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;

                var response = await client.GetAsync("/LootLo/Customer/"+customerId);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<Customer>(readTask);
                    if (result != null)
                        return View(result);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44346");
                    client.DefaultRequestHeaders.Clear();
                    string jsonData = JsonConvert.SerializeObject(customer);
                    var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                    var response = await client.PutAsync("/LootLo/Customer", content);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Details Updated Succesfully";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Message = "Updation Failed";
                    }
                }

                return View(new Customer());
            }

            return View(customer);
        }

        public async Task<IActionResult> Delete()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44346");
                client.DefaultRequestHeaders.Clear();

                int customerId = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "customer").CustomerId;

                var response = await client.DeleteAsync("/LootLo/Customer/" + customerId);

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Register", "Customer");
                }
            }

            return RedirectToAction("Update","Customer");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }
            }

            return RedirectToAction("Login","Customer");
        }
    }
}
