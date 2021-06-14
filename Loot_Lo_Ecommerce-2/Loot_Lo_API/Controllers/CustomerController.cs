using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loot_Lo_API.Controllers
{
    [Route("LootLo/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int? id)
        {
            if (id == null)
                return BadRequest();

            try
            {
                Customer customer = await customerRepository.GetDetails(id);

                if (customer != null)
                    return Ok(customer);

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> PostRegisterCustomer([FromBody] Customer customer)
        {
            try
            {
                int result = await customerRepository.Registration(customer);

                if (result == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutUpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                await customerRepository.UpdateDetails(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    return NotFound();

                return BadRequest();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (id == null)
                return BadRequest();

            try
            {
                int result = await customerRepository.DeleteDetails(id);

                if (result == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> PostLoginCustomer([FromBody] Customer customer)
        {
            try
            {
                Customer cust = await customerRepository.GetDetailsByEmail(customer.CustomerEmail);

                if (cust != null)
                {
                    Customer customer1 = await customerRepository.GetDetailsByEmailAndPassword(customer.CustomerEmail, customer.CustomerPassword);

                    if (customer1 != null)
                        return Ok(customer1);
                    else
                        return NotFound("Wrong Password");
                }
                else
                {
                    return NotFound("Not Registered or incorrect email");
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
