using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Repository
{
    public class ProductRepository : IProductRespository
    {
        private readonly LootLoDbContext lootLoDb;
        
        public ProductRepository(LootLoDbContext lootLoDb)
        {
            this.lootLoDb = lootLoDb;
        }

        public async Task<Product> GetProductById(int? productId)
        {
            if (lootLoDb != null)
            {
                return await lootLoDb.Products.SingleOrDefaultAsync(p => p.ProductId == productId);
            }

            return null;
        }

        public async Task<List<Product>> ProductByCategoryId(int? categoryId)
        {
            if (lootLoDb != null)
            {
                return await lootLoDb.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
            }

            return null;
        }
    }
}
