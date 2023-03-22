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
        }

        private static void LoadDataSample()
        {
            using (var db = new DatabaseContext())
            {
                //Add Employees
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

                //Add LeaveTypes
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

                //Add Leave Status Types
                if (db.StatusList.Count() == 0)
                {
                    var file = File.ReadAllText("StatusDataSample.json");
                    var status = JsonSerializer.Deserialize<List<LeaveType>>(file);

                    if (status != null)
                    {
                        db.AddRange(status);
                        db.SaveChanges();
                    }
                }

                //Add Requests
                if (db.LeaveRequests.Count() == 0)
                {
                    var file = File.ReadAllText("RequestsSampleData.json");
                    var requests = JsonSerializer.Deserialize<List<LeaveRequest>>(file);

                    if (requests != null)
                    {
                        db.AddRange(requests);
                        db.SaveChanges();
                    }
                }
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
            return menuChoice;
        }

        static void MainMenu()
        {
            List<string> mainMenu = new()
            {
                "View Employee and Leave Balance",//1
                "View All Employees and Leave Balance",//2
                "View All Leave Requests",//3
                "View Pending Leave Requests",//4
                "View Approved Leave Requests",//5
                "View Rejected Leave Requests",//6
                "Exit"//7
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(mainMenu);
                switch (menuChoice)
                {
                    case 1:
                        //
                        break;
                    case 2:
                        //
                        break;
                    case 3:
                        //
                        break;
                    case 4:
                        //
                        break;
                    case 5:
                        //
                        break;
                    case 6:
                        //
                        break;
                    case 7:
                        Console.WriteLine("\n\tThanks for your visit!");
                        Thread.Sleep(1000);
                        runLoginMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPlease, choose 1-17 from the menu\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\tPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}