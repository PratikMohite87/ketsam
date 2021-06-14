using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Loot_Lo_API.Models
{
    public class LootLoDbContext : DbContext
    {
        public LootLoDbContext(DbContextOptions<LootLoDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { set; get; }
        public DbSet<Admin> Admins { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<CustomerOrderDetails> CustomerOrderDetails { set; get; }
        public DbSet<OrderedProductQuantity> OrderedProductQuantities { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Cart> Carts { set; get; }
    }
}
