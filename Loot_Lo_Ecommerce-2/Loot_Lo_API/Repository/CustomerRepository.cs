using Loot_Lo_API.Interfaces;
using Loot_Lo_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LootLoDbContext lootLoDb;

        public CustomerRepository(LootLoDbContext lootLoDb)
        {
            this.lootLoDb = lootLoDb;
        }

        public async Task<int> DeleteDetails(int? id)
        {
            Customer customer = await lootLoDb.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer != null)
            {
                lootLoDb.Customers.Remove(customer);

                return await lootLoDb.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<Customer> GetDetails(int? id)
        {
            if (lootLoDb != null)
            {
                return await lootLoDb.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            }

            return null;
        }

        public async Task<int> Registration(Customer customer)
        {
            if (lootLoDb != null)
            {
                await lootLoDb.Customers.AddAsync(customer);

                return await lootLoDb.SaveChangesAsync();
            }

            return 0;
        }

        public async Task UpdateDetails(Customer customer)
        {
            if (lootLoDb != null)
            {
                lootLoDb.Customers.Update(customer);

                await lootLoDb.SaveChangesAsync();
            }
        }

        public async Task<Customer> GetDetailsByEmail(string email)
        {
            Customer customer = await lootLoDb.Customers.SingleOrDefaultAsync(c => c.CustomerEmail == email);
            return customer;
        }

        public async Task<Customer> GetDetailsByEmailAndPassword(string email, string password)
        {
            return await lootLoDb.Customers.Where(c => c.CustomerEmail == email && c.CustomerPassword == password).SingleOrDefaultAsync();
        }
    }
}
