using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Globalization;
using System.Text.Json;

namespace LeaveManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadDataSample();
            MainMenu();
            //GetLeaveRequestData();
        }

        private static void LoadDataSample()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Employees.Count() == 0)
                {
                    var file = File.ReadAllText("EmployeesDataSample.json");
                    var employees = JsonSerializer.Deserialize<List<Employee>>(file);

                    if (employees != null)
                    {
                        db.AddRange(employees);
                        db.SaveChanges();
                    }
                }

                if (db.LeaveTypes.Count() == 0)
                {
                    var file = File.ReadAllText("LeaveTypesDataSample.json");
                    var leaveTypes = JsonSerializer.Deserialize<List<LeaveType>>(file);

                    if (leaveTypes != null)
                    {
                        db.AddRange(leaveTypes);
                        db.SaveChanges();
                    }
                }
                //else
                //{
                //    var leaveTypes = db?.Employees?.ToList();
                //    if (leaveTypes != null)
                //    {
                //        Console.ForegroundColor = ConsoleColor.DarkYellow;
                //        Console.WriteLine("\nWELCOME!");
                //        Console.ResetColor();
                //        Console.WriteLine("\nList of Employees: ");
                //        foreach (var employee in leaveTypes)
                //        {
                //            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Email: {employee.Email}, Leave Balance: {employee.LeaveBalance}");
                //        }
                //    }
                //}
            }
        }

        static int DisplayMenu(List<String> menuItems)
        {

            Console.Clear();
            string welcome1 = "\n\t============ welcome! ============\n";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(welcome1.ToUpper());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\tPlease select one of the options below:\n");
            Console.ResetColor();

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"\n\t{i + 1}. {menuItems[i]}");
            }
            Console.Write($"\nSelect menu ---> ");
            int.TryParse(Console.ReadLine(), out int menuChoice);
            //return menuChoice -= 1;
            return menuChoice;
        }

        static void MainMenu()
        {
            List<string> mainMenu = new()
            {
                "Manage Employees",
                "Manage Leave Request",
                "Manage Leave Type",
                "View Reports",
                "Exit"
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(mainMenu);
                switch (menuChoice)
                {
                    case 1:
                        ManageEmployeesMenu();
                        break;
                    case 2:
                        ManageLeaveRequestMenu();
                        break;
                    case 3:
                        ManageLeaveTypeMenu();
                        break;
                    case 4:
                        ViewReportsMenu();
                        break;
                    case 5:
                        Console.WriteLine("\n\tThanks for your visit!");
                        Thread.Sleep(1000);
                        runLoginMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPlease, choose 1-5 from the menu\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\tPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void ManageEmployeesMenu()
        {
            List<string> manageEmployeesMenu = new()
            {
                "Add Employee",
                "Update Employee",
                "Delete Employee",
                "Back to Main Menu"
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(manageEmployeesMenu);
                switch (menuChoice)
                {
                    case 1:
                        //Add Employee
                        Console.Clear();
                        Employee employee = GetEmployeeData();
                        bool isAdded = DatabaseContext.AddEmployee(employee);
                        if (isAdded)
                        {
                            Console.WriteLine($"\n\tEmployee successfully added!");
                        }
                        break;
                    case 2:
                        //Update Employee
                        string employeeEmail = GetEmployee();
                        if (employeeEmail != null)
                        {
                            Console.WriteLine($"\n\tPlease enter the new data to update");
                            Employee employeeToUpdate = GetEmployeeData();
                            DatabaseContext.UpdateEmployee(employeeToUpdate, employeeEmail);
                        }
                        break;
                    case 3:
                        //Delete Employee
                        string email = GetEmployee();
                        bool isDeleted = DatabaseContext.DeleteEmployee(email);
                        if (isDeleted)
                        {
                            Console.WriteLine($"\n\tEmployee successfully removed!");
                        }
                        break;
                    case 4:
                        //Back to Main Menu
                        MainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\tPlease, choose 1-4 from the menu\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\tPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void ManageLeaveRequestMenu()
        {
            Console.Clear();
            List<string> leaveRequestMenu = new()
            {
                "Add Leave Request",
                "Update Leave Request",
                "Update Leave Request Status",
                "Delete Leave Request",
                "Back to Main Menu"
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(leaveRequestMenu);
                switch (menuChoice)
                {
                    case 1:
                        //Add Leave Request
                        Console.Clear();
                        LeaveRequest request = GetLeaveRequestData();
                        bool isAdded = DatabaseContext.AddLeaveRequest(request);
                        if (isAdded)
                        {
                            Console.WriteLine($"\n\tRequest successfully added!");
                        }
                        break;
                    case 2:
                        //Update Leave Request
                        break;
                    case 3:
                        //Update Leave Request Status
                        break;
                    case 4:
                        //Delete Leave Request
                        break;
                    case 5:
                        //Back to Main Menu
                        MainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPlease, choose 1-5 from the menu\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\tPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void ManageLeaveTypeMenu()
        {
            Console.Clear();
            List<string> leaveTypeMenu = new()
            {
                "View All Leave Types",
                "Add Leave Type",
                "Update Leave Type",
                "Back to Main Menu"
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(leaveTypeMenu);
                switch (menuChoice)
                {
                    case 1:
                        //View All Leave Types
                        break;
                    case 2:
                        //Add Leave Type
                        break;
                    case 3:
                        //Update Leave Type
                        break;
                    case 4:
                        //Back to Main Menu
                        MainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPlease, choose 1-5 from the menu\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\tPress any key to continue...");
                Console.ReadKey();
            }

        }

        private static void ViewReportsMenu()
        {
            Console.Clear();
            List<string> reportsMenu = new()
            {
                "View Employee and Leave Balance",
                "View All Employees and Leave Balance",
                "View All Leave Requests",
                "View Pending Leave Requests",
                "View Approved Leave Requests",
                "View Rejected Leave Requests",
                "Back to Main Menu"
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(reportsMenu);
                switch (menuChoice)
                {
                    case 1:
                        //View Employee and Leave Balance
                        break;
                    case 2:
                        //View All Employees and Leave Balance
                        break;
                    case 3:
                        //View All Leave Requests
                        break;
                    case 4:
                        //View Pending Leave Requests
                        break;
                    case 5:
                        //View Approved Leave Requests
                        break;
                    case 6:
                        //View Rejected Leave Requests
                        break;
                    case 7:
                        //Back to Main Menu
                        MainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPlease, choose 1-7 from the menu\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\tPress any key to continue...");
                Console.ReadKey();
            }

        }

        private static Employee GetEmployeeData()
        {
            Console.Write("\n\tType the first Name: ");
            string firstName = Console.ReadLine();
            Console.Write("\n\tType the last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("\n\tType the email: ");
            string email = Console.ReadLine();
            Console.Write("\n\tType Leave Balance in Days: ");
            int.TryParse(Console.ReadLine(), out int leaveBalance);

            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email))
            {
                Console.WriteLine("\n\tPlease enter a valid input");
                return null;
            }

            Employee employee = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                LeaveBalance = leaveBalance
            };
            return employee;
        }
        private static string GetEmployee()
        {
            Console.Clear();
            Console.Write("\n\tType the employee's email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("\n\tInvalid Input");
                return null;
            }
            else
            {
                var employee = DatabaseContext.GetEmployeeByEmail(email);
                if (employee != null)
                {
                    Console.WriteLine($"\n\tName: {employee.FirstName} {employee.LastName}, Leave Balance: {employee.LeaveBalance}");
                    //Console.ReadLine();
                    return email;
                }
                else { return null; }
            }
        }

        enum LeaveStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3
        }

        private static LeaveRequest GetLeaveRequestData()
        {
            //Get Employee
            Console.Write("\n\tType the employee's email: ");
            string email = Console.ReadLine();
            var employee = DatabaseContext.GetEmployeeByEmail(email);
            int employeeId = employee.EmployeeId;

            //Get LeaveType Id by Name
            Console.WriteLine("\n\tChoose the motive of the Request: ");
            var leaveType = DatabaseContext.GetListLeaveType();
            for (int i = 0; i < leaveType.Count; i++)
            {
                Console.WriteLine($"\n\t{i + 1}. {leaveType[i].LeaveTypeName}");
            }
            Console.Write("\nType your choice ---> ");
            int.TryParse(Console.ReadLine(), out int leaveTypeChoice);

            if (leaveTypeChoice <= 0 || leaveTypeChoice > leaveType.Count)
            {
                Console.WriteLine("\n\tPlease enter a valid choice");
                return null;
            }

            Console.Write("\n\tType the StartDate: ");
            string startDateString = Console.ReadLine();
            DateTime startDate = ParseStringToDate(startDateString);

            Console.Write("\n\tType the EndDate: ");
            string endDateString = Console.ReadLine();
            DateTime endDate = ParseStringToDate(endDateString);

            int statusId = (int)LeaveStatus.Pending;

            TimeSpan span = endDate - startDate;
            float requestedDays = (float)span.TotalDays + 1;

            if (string.IsNullOrEmpty(startDateString) ||
                string.IsNullOrEmpty(endDateString) ||
                string.IsNullOrEmpty(email))
            {
                Console.WriteLine("\n\tPlease enter a valid input");
                return null;
            }

            LeaveRequest leaveRequest = new()
            {
                FkEmployeeId = employeeId,
                FkLeaveTypeId = leaveTypeChoice,
                RequestStartDate = startDate,
                RequestEndDate = endDate,
                RequestedDays = requestedDays,
                FkStatusId = statusId
            };
            return leaveRequest;
        }

        static DateTime ParseStringToDate(string dateString)
        {
            string dateFormat = "dd-MM-yyyy"; //expected date format
            if (string.IsNullOrEmpty(dateString))
            {
                throw new ArgumentException("\n\tInvalid date.");
            }
            return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
        }

        private static void ViewEmployeesAndLeaveBalance()
        {

        }
    }
}