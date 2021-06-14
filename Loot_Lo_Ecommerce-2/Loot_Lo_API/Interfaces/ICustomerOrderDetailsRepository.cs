using Loot_Lo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Interfaces
{
    public interface ICustomerOrderDetailsRepository
    {
        Task<int> AddOrderDetails(CustomerOrderDetails customerOrderDetails);
        Task<int> DeleteOrderDetail(int? orderId);
        Task UpdateOrderDetails(CustomerOrderDetails customerOrderDetails);
        Task<List<CustomerOrderDetails>> GetOrderDetailsByCustId(int? customerId);
        Task<int> DeleteOrderDetailsByCustId(int? customerId);
    }
}
