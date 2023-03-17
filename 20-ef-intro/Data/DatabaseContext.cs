using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFirstEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstEntity.Data
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public void SeedData()
        {
            var employee = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Kalle",
                    LastName = "Tester",
                    Email = "kalle@tester.com"
                },
                new Employee
                {
                    FirstName = "Krille",
                    LastName = "Tester",
                    Email = "krille@tester.com"
                }
            };

            Employees.AddRange(employee);
            SaveChanges();
        }
    }
}

