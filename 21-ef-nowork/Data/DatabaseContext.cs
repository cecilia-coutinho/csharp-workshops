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

        //CRUD Operations starts here

        //Create Employee
        public static bool AddEmployee(Employee newEmployee)
        {
            using (var db = new DatabaseContext())
            {
                if (newEmployee == null)
                {
                    throw new ArgumentNullException(nameof(newEmployee), "Error: Employee not added. Please enter a valid data.");
                }

                else
                {
                    try
                    {
                        db.Employees.Add(newEmployee);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        bool employeeExists = db.Employees.Any(e => e.Email == newEmployee.Email);

                        if (employeeExists)
                        {
                            throw new Exception("\n\tError: Employee already exists in the database.");
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
                try
                {
                    var employee = db.Employees.FirstOrDefault(e => e.Email == email);
                    if (employee == null)
                    {
                        Console.WriteLine($"\n\tEmployee with email '{email}' not found.");
                    }
                    return employee;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: Not found", ex);
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
                        throw new Exception("\n\tError: please check yor data.");
                    }
                    else
                    {
                        throw new Exception("\n\tError: Employee not updated.", ex);
                    }
                }
            }
        }

        //Delete Employee
        public static bool DeleteEmployee(string email)
        {
            using (var db = new DatabaseContext())
            {
                var employee = db
                .Employees
                .Where(e => e.Email == email)
                .First();

                if (email == null)
                {
                    throw new ArgumentNullException($"{nameof(email)}, Error: Delete failed! Employee not found.");
                }

                db.Employees.Remove(employee);
                db.SaveChanges();
                return db.Employees.FirstOrDefault(e => e.Email == email) == null;
            }
        }

        // Create LeaveType
        public static bool AddLeaveRequest(LeaveRequest newRequest)
        {
            using (var db = new DatabaseContext())
            {
                if (newRequest == null)
                {
                    throw new ArgumentNullException(nameof(newRequest), "Error: Employee not added. Please enter a valid data.");
                }
                else
                {
                    db.LeaveRequests.Add(newRequest);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        // Read LeaveType
        public static List<LeaveType> GetListLeaveType()
        {
            using (var db = new DatabaseContext())
            {
                return db.LeaveTypes.ToList();
            }
        }

        // Update Leave Type
    }
}
