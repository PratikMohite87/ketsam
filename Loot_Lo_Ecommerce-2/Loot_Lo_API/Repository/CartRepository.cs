using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly LootLoDbContext lootLoDb;

        public CartRepository(LootLoDbContext lootLoDb)
        {
            this.lootLoDb = lootLoDb;
        }

        public async Task<int> AddToCart(Cart cart)
        {
            if (lootLoDb != null)
            {
                await lootLoDb.Carts.AddAsync(cart);

                return await lootLoDb.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<List<Cart>> CartByCustId(int? customerId)
        {
            if (lootLoDb != null)
            {
                List<Cart> carts = await lootLoDb.Carts.Where(c => c.CustomerId == customerId).ToListAsync();

                return carts;
            }

            return null;
        }

        public async Task<int> DeleteCart(int? cartId)
        {
            if (lootLoDb != null)
            {
                Cart cart = await lootLoDb.Carts.SingleOrDefaultAsync(c => c.CartId == cartId);

                if (cart != null)
                {
                    lootLoDb.Carts.Remove(cart);

                    return await lootLoDb.SaveChangesAsync();
                }
            }

            return 0;
        }

        public async Task<int> DeleteCartOfCust(int? customerId)
        {
            if (lootLoDb != null)
            {
                List<Cart> carts = await lootLoDb.Carts.Where(c => c.CustomerId == customerId).ToListAsync();
                foreach (var item in carts)
                {
                    lootLoDb.Carts.Remove(item);
                }

                return await lootLoDb.SaveChangesAsync();
            }

            return 0;
        }
    }
}
