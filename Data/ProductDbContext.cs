using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;
using System.Reflection.Emit;

namespace OrderSystem.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                 .HasMany(c => c.Products)
                 .WithOne(p => p.Category)
                 .HasForeignKey(p => p.CategoryId);


            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" }
            );

            // Seed products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", CategoryId = 1, Price = 999.99M },
                new Product { Id = 2, Name = "Smartphone", CategoryId = 1, Price = 599.99M },
                new Product { Id = 3, Name = "Novel", CategoryId = 2, Price = 14.99M }
            );
        }
    }
}
