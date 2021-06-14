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
    public class OrderedProductQuantityController : ControllerBase
    {
        private readonly IOrderedProductQuantityRepository orderedProductQuantityRepository;

        public OrderedProductQuantityController(IOrderedProductQuantityRepository orderedProductQuantityRepository)
        {
            this.orderedProductQuantityRepository = orderedProductQuantityRepository;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderedProductQuantityByOrderId(int? orderId)
        {
            if (orderId == null)
            {
                return BadRequest();
            }

            try
            {
                List<OrderedProductQuantity> orderedProductQuantities = await orderedProductQuantityRepository.GetOrderedProductByOrderId(orderId);

                if (orderedProductQuantities != null)
                {
                    return Ok(orderedProductQuantities);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
