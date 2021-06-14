using Loot_Lo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Interfaces
{
    public interface IOrderedProductQuantityRepository
    {
        Task UpdateProductQuantity(OrderedProductQuantity orderedProductQuantity);
        Task<int> DeleteOrderedProduct(int? orderedProductQuantityId);
        Task<List<OrderedProductQuantity>> GetOrderedProductByOrderId(int? orderId);
    }
}
