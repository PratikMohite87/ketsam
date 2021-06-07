using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Controllers
{
    [Route("LootLo/[controller]")]
    [ApiController]
    public class CustomerOrderDetailsController : ControllerBase
    {
        private readonly ICustomerOrderDetailsRepository customerOrderDetailsRepository;
        private readonly IOrderedProductQuantityRepository orderedProductQuantityRepository;

        public CustomerOrderDetailsController(ICustomerOrderDetailsRepository customerOrderDetailsRepository,
           IOrderedProductQuantityRepository orderedProductQuantityRepository)
        {
            this.customerOrderDetailsRepository = customerOrderDetailsRepository;
            this.orderedProductQuantityRepository = orderedProductQuantityRepository;
        }

        [HttpPost]
        [Route("addorder")]
        public async Task<IActionResult> AddOrder([FromBody] CustomerOrderDetails customerOrderDetails)
        {
            try
            {
                var orderId = await customerOrderDetailsRepository.AddOrderDetails(customerOrderDetails);
                if (orderId > 0)
                {
                    return Ok(orderId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await customerOrderDetailsRepository.DeleteOrderDetail(id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                List<CustomerOrderDetails> orderDetailsList = await customerOrderDetailsRepository.GetOrderDetailsByCustId(id);

                if (orderDetailsList == null)
                {
                    return NotFound();
                }

                for (int i = 0; i < orderDetailsList.Count; i++)
                {
                    orderDetailsList[i].OrderedProductQuantity = await orderedProductQuantityRepository.GetOrderedProductByOrderId(orderDetailsList[i].OrderId);
                }

                return Ok(orderDetailsList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] CustomerOrderDetails customerOrderDetails)
        {
            try
            {
                await customerOrderDetailsRepository.UpdateOrderDetails(customerOrderDetails);

                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    return NotFound();

                return BadRequest();
            }
        }

        [HttpDelete("deleteorder/{id}")]
        public async Task<IActionResult> DeleteOrderByCustId(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await customerOrderDetailsRepository.DeleteOrderDetailsByCustId(id);

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
    }
}
