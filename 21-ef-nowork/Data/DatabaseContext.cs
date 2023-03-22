using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace LeaveManagementSystem.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Status> StatusList { get; set; }
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

            modelBuilder.Entity<LeaveType>()
                .HasIndex(u => u.LeaveTypeName)
                .IsUnique();

            modelBuilder.Entity<Status>()
                .HasIndex(u => u.StatusName)
                .IsUnique();

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(e => e.Employees)
                .WithMany(r => r.LeaveRequests)
                .HasForeignKey(lr => lr.FkEmployeeId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(e => e.LeaveTypes)
                .WithMany(r => r.LeaveRequests)
                .HasForeignKey(lr => lr.FkLeaveTypeId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(e => e.StatusList)
                .WithMany(r => r.LeaveRequests)
                .HasForeignKey(lr => lr.FkStatusId);
        }
    }
}
