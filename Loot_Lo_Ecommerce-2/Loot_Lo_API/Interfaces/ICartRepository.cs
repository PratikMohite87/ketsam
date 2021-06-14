using Loot_Lo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Interfaces
{
    public interface ICartRepository
    {
        Task<int> AddToCart(Cart cart);
        Task<List<Cart>> CartByCustId(int? customerId);
        Task<int> DeleteCartOfCust(int? customerId);
        Task<int> DeleteCart(int? cartId);
    }
}
