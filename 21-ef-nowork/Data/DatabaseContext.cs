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
        }

        //CRUD Operations starts here

        //Create Employee
        public static void AddEmployee(Employee newEmployee)
        {
            using (var db = new DatabaseContext())
            {
                if (newEmployee == null)
                {
                    Console.WriteLine("\n\tError: Employee not added. Please enter a valid data.");
                    return;
                }
                else
                {
                    try
                    {
                        db.Employees.Add(newEmployee);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        bool employeeExists = db.Employees.Any(e => e.Email == newEmployee.Email);

                        if (employeeExists)
                        {
                            Console.WriteLine("\n\tError: Employee already exists in the database.", ex);
                            return;
                        }
                        else
                        {
                            throw new Exception("\n\tError: Employee not added.", ex);
                        }
                    }
                }
            }
        }

        //Read Employee
        public static Employee GetEmployeeByEmail(string email)
        {
            using (var db = new DatabaseContext())
            {
                var employee = db.Employees.FirstOrDefault(e => e.Email == email);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    Console.WriteLine("\n\tEmployee not found!");
                    return null;
                }
            }
        }

        //Update Employee
        public static void UpdateEmployee(Employee updatedEmployee, string email)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    var employee = db
                    .Employees
                    .Where(e => e.Email == email)
                    .First();

                    updatedEmployee.EmployeeId = employee.EmployeeId; //This is important when we first create an object (NewObj), in which the default Id = 0. We can not change an existing key.
                    if (employee != null && updatedEmployee != null)
                    {
                        db.Entry(employee).CurrentValues.SetValues(updatedEmployee);
                        db.SaveChanges();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n\tEmployee Updated Successfully!" +
                            $"\n\tName: {employee.FirstName} {employee.LastName}" +
                            $"\n\tEmail: {employee.Email}" +
                            $"\n\tLeave Balance: {employee.LeaveBalance}" + $"");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    if (updatedEmployee == null)
                    {
                        Console.WriteLine("\n\tError: please check yor data.");
                    }
                    else
                    {
                        throw new Exception("\n\tError: Employee not updated.", ex);
                    }
                }
            }
        }

        //Delete Employee
        public static void DeleteEmployee(string email)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    var employee = db
                    .Employees
                    .Where(e => e.Email == email)
                    .First();

                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    Console.WriteLine($"\n\tEmployee successfully removed!");
                }
                catch (Exception ex)
                {
                    if (email == null)
                    {
                        Console.WriteLine("\n\tError: Delete failed! Employee not found.");
                        return;
                    }
                    else
                    {
                        throw new Exception("\n\tError: Employee not removed.", ex);
                    }
                }
            }
        }
    }
}
