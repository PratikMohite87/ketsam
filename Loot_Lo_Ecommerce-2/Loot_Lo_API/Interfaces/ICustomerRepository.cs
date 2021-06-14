using Loot_Lo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_API.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> Registration(Customer customer);
        Task<Customer> GetDetails(int? id);
        Task UpdateDetails(Customer customer);
        Task<int> DeleteDetails(int? id);
        Task<Customer> GetDetailsByEmail(string email);
        Task<Customer> GetDetailsByEmailAndPassword(string email, string password);
    }
}
