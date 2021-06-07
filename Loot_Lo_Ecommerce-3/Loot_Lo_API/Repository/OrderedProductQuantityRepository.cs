using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Repository
{
    public class OrderedProductQuantityRepository : IOrderedProductQuantityRepository
    {
        private readonly LootLoDbContext lootLoDb;

        public OrderedProductQuantityRepository(LootLoDbContext lootLoDb)
        {
            this.lootLoDb = lootLoDb;
        }

        public async Task<int> DeleteOrderedProduct(int? orderedProductQuantityId)
        {
            int result = 0;

            if (lootLoDb != null)
            {
                OrderedProductQuantity orderedProductQuantity = await lootLoDb.OrderedProductQuantities.FirstOrDefaultAsync(po => po.OrderedProductQuantityId == orderedProductQuantityId);

                if (orderedProductQuantity != null)
                {
                    lootLoDb.OrderedProductQuantities.Remove(orderedProductQuantity);

                    result = await lootLoDb.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task<List<OrderedProductQuantity>> GetOrderedProductByOrderId(int? orderId)
        {
            if (lootLoDb != null)
            {
                return await lootLoDb.OrderedProductQuantities.Where(op => op.OrderId == orderId).ToListAsync();
            }

            return null;
        }

        public async Task UpdateProductQuantity(OrderedProductQuantity orderedProductQuantity)
        {
            if (lootLoDb != null)
            {
                lootLoDb.OrderedProductQuantities.Update(orderedProductQuantity);

                await lootLoDb.SaveChangesAsync();
            }
        }
    }
}
