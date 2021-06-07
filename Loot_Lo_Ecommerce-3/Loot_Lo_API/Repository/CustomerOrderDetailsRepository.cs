using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Repository
{
    public class CustomerOrderDetailsRepository : ICustomerOrderDetailsRepository
    {
        private readonly LootLoDbContext lootLoDb;

        public CustomerOrderDetailsRepository(LootLoDbContext lootLoDb)
        {
            this.lootLoDb = lootLoDb;
        }

        public async Task<int> AddOrderDetails(CustomerOrderDetails customerOrderDetails)
        {
            if (lootLoDb != null)
            {
                await lootLoDb.CustomerOrderDetails.AddAsync(customerOrderDetails);
                await lootLoDb.SaveChangesAsync();

                return customerOrderDetails.OrderId;
            }

            return 0;
        }

        public async Task<int> DeleteOrderDetailsByCustId(int? customerId)
        {
            if (lootLoDb != null)
            {
                var result = await lootLoDb.CustomerOrderDetails.Where(o => o.CustomerId == customerId).ToListAsync();

                lootLoDb.CustomerOrderDetails.RemoveRange(result);
                return await lootLoDb.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> DeleteOrderDetail(int? orderId)
        {
            int result = 0;

            if (lootLoDb != null)
            {
                CustomerOrderDetails customerOrderDetails = await lootLoDb.CustomerOrderDetails.FirstOrDefaultAsync(o => o.OrderId == orderId);

                if (customerOrderDetails != null)
                {
                    lootLoDb.CustomerOrderDetails.Remove(customerOrderDetails);

                    result = await lootLoDb.SaveChangesAsync();
                }

                return result;
            }

            return result;
        }

        public async Task<List<CustomerOrderDetails>> GetOrderDetailsByCustId(int? customerId)
        {
            if (lootLoDb != null)
            {
                List<CustomerOrderDetails> orderDetailsList = await lootLoDb.CustomerOrderDetails.Where(O => O.CustomerId == customerId).ToListAsync();

                return orderDetailsList;
            }

            return null;
        }

        public async Task UpdateOrderDetails(CustomerOrderDetails customerOrderDetails)
        {
            if (lootLoDb != null)
            {
                lootLoDb.CustomerOrderDetails.Update(customerOrderDetails);
                await lootLoDb.SaveChangesAsync();
            }
        }
    }
}
