using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System;

namespace Shop.DataAccess
{
    public class Context : DbContext
    {
        private readonly string connectionString;
        public Context(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShopBasket> ShopBaskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
