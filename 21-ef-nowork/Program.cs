using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Text.Json;

namespace LeaveManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoadSampleData();
            //GetEmployee();
            MainMenu();
        }

        private static void LoadSampleData()
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
                //else
                //{
                //    var employees = db?.Employees?.ToList();
                //    if (employees != null)
                //    {
                //        Console.ForegroundColor = ConsoleColor.DarkYellow;
                //        Console.WriteLine("\nWELCOME!");
                //        Console.ResetColor();
                //        Console.WriteLine("\nList of Employees: ");
                //        foreach (var employee in employees)
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
            Console.Write($"\n\tSelect menu ---> ");
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
                        DatabaseContext.AddEmployee(employee);
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
                        DatabaseContext.DeleteEmployee(email);
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
                "Manage Employees",
                "Manage Leave Request",
                "Manage Leave Type",
                "View Reports",
                "Exit"
            };
            //bool runLoginMenu = true;

            //while (runLoginMenu)
            //{
            //    int menuChoice = DisplayMenu(leaveRequestMenu);
            //    switch (menuChoice)
            //    {
            //        case 1:
            //            ManageEmployees();
            //            break;
            //        case 2:
            //            ManageLeaveRequest();
            //            break;
            //        case 3:
            //            ManageLeaveType();
            //            break;
            //        case 4:
            //            ViewReports();
            //            break;
            //        case 5:
            //            Console.WriteLine("\n\tThanks for your visit!");
            //            Thread.Sleep(1000);
            //            runLoginMenu = false;
            //            break;
            //        default:
            //            Console.Clear();
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.WriteLine("\n\tPlease, choose 1-5 from the menu\n");
            //            Console.ResetColor();
            //            break;
            //    }
            //    Console.WriteLine("\n\tPress any key to continue...");
            //    Console.ReadKey();
            //}
        }

        private static void ManageLeaveTypeMenu()
        {

        }

        private static void ViewReportsMenu()
        {

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
            Console.Write("\n\tType the email: ");
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

        private static void ViewEmployeesAndLeaveBalance()
        {

        }

        static void GoBackMenuOptions()
        {
            //option to go back to the main menu
            Console.WriteLine("\nPress ENTER to go back to the menu.\n");
            Console.ReadLine();
        }
    }
}