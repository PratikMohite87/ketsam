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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRespository productRespository;

        public CartController(ICartRepository cartRepository, IProductRespository productRespository)
        {
            this.cartRepository = cartRepository;
            this.productRespository = productRespository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAddCart(Cart cart)
        {
            try
            {
                int result = await cartRepository.AddToCart(cart);

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

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerCart(int? customerId)
        {
            if (customerId == null)
            {
                return BadRequest();
            }

            try
            {
                List<Cart> carts = await cartRepository.CartByCustId(customerId);

                if (carts != null)
                {
                    foreach(var item in carts)
                    {
                        item.Product = await productRespository.GetProductById(item.ProductId);
                    }

                    return Ok(carts);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerCart(int? customerId)
        {
            if (customerId == null)
            {
                return BadRequest();
            }

            try
            {
                int result = await cartRepository.DeleteCartOfCust(customerId);

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

        [HttpDelete("deletecart/{cartId}")]
        public async Task<IActionResult> DeleteCart(int? cartId)
        {
            if (cartId == null)
            {
                return BadRequest();
            }

            try
            {
                int result = await cartRepository.DeleteCart(cartId);

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
