using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data
{
    public class ApplicationDbContextConfigurations
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Add any additional entity configurations here
        }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Add any seed data here
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Code = "P001", Name = "Product 1", Price = 9.99f, IsActive = true },
                new Product { Id = 2, Code = "P002", Name = "Product 2", Price = 12.00f, IsActive = true },
                new Product { Id = 3, Code = "P003", Name = "Product 3", Price = 13.00f, IsActive = true },
                new Product { Id = 4, Code = "P004", Name = "Product 4", Price = 14.00f, IsActive = true },
                new Product { Id = 5, Code = "P005", Name = "Product 5", Price = 15.00f, IsActive = true },
                new Product { Id = 6, Code = "P006", Name = "Product 6", Price = 16.00f, IsActive = true },
                new Product { Id = 7, Code = "P007", Name = "Product 7", Price = 17.00f, IsActive = true },
                new Product { Id = 8, Code = "P008", Name = "Product 8", Price = 18.00f, IsActive = true },
                new Product { Id = 9, Code = "P009", Name = "Product 9", Price = 19.00f, IsActive = true },
                new Product { Id = 10, Code = "P010", Name = "Product 10", Price = 19.99f, IsActive = true }
            );

        }

    }
}
