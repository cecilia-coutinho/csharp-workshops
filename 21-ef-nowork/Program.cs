using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using System.Collections.Generic;
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
                "View All Employees and Leave Balance",
                "View All Leave Requests",
                "View Pending Leave Requests",
                "View Approved Leave Requests",
                "View Rejected Leave Requests",
                "View All Leave Types",
                "Exit"
            };
            bool runLoginMenu = true;

            while (runLoginMenu)
            {
                int menuChoice = DisplayMenu(mainMenu);
                switch (menuChoice)
                {
                    case 1:
                        // View All Employees and Leave Balance
                        using (var db = new DatabaseContext())
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t============ ALL EMPLOYEES: ============\n");
                            var employee = db.Employees.ToList();
                            for (int i = 0; i < employee.Count; i++)
                            {
                                Console.WriteLine($"\n\t{i + 1}. " +
                                    $"{employee[i].FirstName} {employee[i].LastName}, " +
                                    $"email: {employee[i].Email}, " +
                                    $"Leave Balance: {employee[i].LeaveBalance}");
                            }
                        }
                        break;
                    case 2:
                        // View All Leave Requests
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n=============== PENDING: ===============");
                        Console.ResetColor();
                        GetLeaveRequests(LeaveStatus.Pending.ToString());

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n=============== APPROVED: ===============");
                        Console.ResetColor();
                        GetLeaveRequests(LeaveStatus.Approved.ToString());

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n=============== REJECTED: ===============");
                        Console.ResetColor();
                        GetLeaveRequests(LeaveStatus.Rejected.ToString());

                        break;
                    case 3:
                        // View Pending Leave Requests
                        Console.Clear();
                        Console.WriteLine("\n\t=============== PENDING: ===============");
                        GetLeaveRequests(LeaveStatus.Pending.ToString());
                        break;
                    case 4:
                        // View Approved Leave Requests
                        Console.Clear();
                        Console.WriteLine("\n\t=============== APPROVED: ===============");
                        GetLeaveRequests(LeaveStatus.Approved.ToString());
                        break;
                    case 5:
                        // View Rejected Leave Requests
                        Console.Clear();
                        Console.WriteLine("\n\t=============== REJECTED: ===============");
                        GetLeaveRequests(LeaveStatus.Rejected.ToString());
                        break;
                    case 6:
                        // View All Leave Types
                        Console.Clear();
                        ;
                        using (var db = new DatabaseContext())
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t=============== LEAVE TYPES: ===============");
                            var leaveTypes = db.LeaveTypes.ToList();
                            for (int i = 0; i < leaveTypes.Count; i++)
                            {
                                Console.WriteLine($"\n\t{i + 1}. " +
                                    $"{leaveTypes[i].LeaveTypeName}:  {leaveTypes[i].LeaveTypeDescription}");
                            }
                        }

                        break;
                    case 7:
                        Console.WriteLine("\n\tThanks for your visit!");
                        Thread.Sleep(1000);
                        runLoginMenu = false;
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
        private static void GetLeaveRequests(string statusName)
        {
            using (var db = new DatabaseContext())
            {
                var employees = db.Employees;
                var requests = db.LeaveRequests;
                var statusList = db.StatusList;
                var leaveTypes = db.LeaveTypes;

                var query = from lr in requests
                            join emp in employees on lr.FkEmployeeId equals emp.EmployeeId
                            join lt in leaveTypes on lr.FkLeaveTypeId equals lt.LeaveTypeId
                            join st in statusList on lr.FkStatusId equals st.StatusId
                            where st.StatusName == statusName
                            select new
                            {
                                emp.FirstName,
                                emp.LastName,
                                lr.RequestStartDate,
                                lr.RequestEndDate,
                                lr.RequestedDays,
                                lr.RequestCreatedOn,
                                lt.LeaveTypeName,
                                st.StatusName
                            };

                int count = 1;

                foreach (var item in query)
                {
                    string employeeName = item.FirstName + " " + item.LastName;
                    string startDate = item.RequestStartDate.ToString("dd-MM-yyyy");
                    string endDate = item.RequestEndDate.ToString("dd-MM-yyyy");
                    float requestLength = item.RequestedDays;
                    string createdOn = item.RequestCreatedOn.ToString("dd-MM-yyyy");
                    string motive = item.LeaveTypeName;
                    string status = item.StatusName;

                    Console.WriteLine($"\n\t{count}. " +
                    $"{employeeName}: \n\t{startDate} to {endDate} ({requestLength} days), " +
                    $"\n\tMotive: {motive}, Status: {status}\n" +
                    $"\n\tRequest created on {createdOn}");
                    Console.WriteLine("-------------------------------");
                    count++;
                }
            }
        }

        enum LeaveStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3
        }
    }
}