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
    public class ProductController : ControllerBase
    {
        private readonly IProductRespository productRepository;

        public ProductController(IProductRespository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(int? categoryId)
        {
            if (categoryId == null)
                return BadRequest();

            try
            {
                List<Product> products = await productRepository.ProductByCategoryId(categoryId);

                if (products != null)
                    return Ok(products);

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
