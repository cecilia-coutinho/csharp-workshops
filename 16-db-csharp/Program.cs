using System;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Workshop16DbCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunMenu();
        }

        static void RunMenu()
        {
            bool runMenu = true;

            while (runMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\tVälkommen till databasen! Vänligen välj ett av nedanstående alternativ:\n");
                Console.ResetColor();

                Console.WriteLine("\n\t1. Lista studenter\n" +
                            "\n\t2. Lista kurser\n" +
                            "\n\t3. Skapa student\n" +
                            "\n\t4. Skapa kurs\n" +
                            "\n\t5. Byt lösenord\n" +
                            "\n\t6. Redigera kurs\n" +
                            "\n\t7. Radera kurs\n" +
                            "\n\tA.Avsluta\n");
                Console.Write("\t----> ");

                int.TryParse(Console.ReadLine(), out int menuChoice);

                switch (menuChoice)
                {
                    case 1:
                        //1. Lista studenter
                        Console.Clear();
                        GetAllStudents();
                        GoBackMenuOptions();
                        break;
                    case 2:
                        //2. Lista kurser
                        Console.Clear();
                        GetAllCourses();
                        GoBackMenuOptions();
                        break;
                    case 3:
                        //3. Skapa student
                        Console.Clear();
                        CreateStudent();
                        GoBackMenuOptions();
                        break;
                    case 4:
                        //4. Skapa kurs
                        Console.Clear();
                        CreateCourse();
                        GoBackMenuOptions();
                        break;
                    case 5:
                        //5. Byt lösenord
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\tcoming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 6:
                        //6. Redigera kurs
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\tcoming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 7:
                        //7. Radera kurs
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n\tcoming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 0:
                        //A.Avsluta
                        Console.Clear();
                        Console.WriteLine("\n\tTack för att du använde databasen och välkommen åter!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        InvalidOption();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tVänligen välj 1-7 från menyn eller A för att logga ut\n");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                }

            }
        }

        static void GoBackMenuOptions()
        {
            Console.WriteLine("\n\tPress ENTER to go back to the menu.\n");
            Console.ReadLine();
        }
        static void InvalidOption()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tERROR: Invalid Option!".ToUpper());
            Console.ResetColor();
        }

        static void GetAllStudents()
        {
            List<StudentModel> students = PostgresDataAccess.GetAllStudents();

            if (students != null && students.Count > 0)
            {
                Console.WriteLine($"\n\tDet finns {students.Count} elever: ");
                foreach (var student in students)
                {
                    Console.WriteLine($"\n\t- Student: {student.first_name} {student.last_name}, {student.age} år gammal, email: {student.email}");
                }
            }
            else
            {
                Console.WriteLine($"\tInga studenter hittades");
            }
        }

        static void GetAllCourses()
        {
            List<CourseModel> courses = PostgresDataAccess.GetAllCourses();

            if (courses != null && courses.Count > 0)
            {
                Console.WriteLine($"\n\tDet finns {courses.Count} kurser: ");
                foreach (var course in courses)
                {
                    string courseStart = course.start_date.ToString("dd-MM-yyyy");
                    string courseEnd = course.end_date.ToString("dd-MM-yyyy");

                    Console.WriteLine($"\n\t- Kurs: {course?.name?.ToUpper()}, {course?.points} points, " +
                        $"start: {courseStart}, slut: {courseEnd}");
                }
            }
            else
            {
                Console.WriteLine($"\tInga kurs hittades");
            }
        }
        static void CreateStudent()
        {
            Console.Write("\n\tType first name: ");
            string? firstName = Console.ReadLine()?.ToLower();
            Console.Write("\tType last name: ");
            string? lastName = Console.ReadLine()?.ToLower();
            Console.Write("\tType email: ");
            string? email = Console.ReadLine()?.ToLower();
            Console.Write("\tType age: ");
            int.TryParse(Console.ReadLine(), out int age);
            Console.Write("\tType password: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || !IsValidEmail(email) || age <= 0 || string.IsNullOrWhiteSpace(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tPlease enter a value for all required fields (firstname, lastname, a valid email, age, password).");
                Console.ResetColor();
                return;
            }

            StudentModel student = new StudentModel();
            {
                student.first_name = firstName;
                student.last_name = lastName;
                student.email = email;
                student.age = age;
                student.password = password;
            };
            PostgresDataAccess.CreateNewStudent(student);
            Console.WriteLine($"\n\tNEW STUDENT: name: {student.first_name} {student.last_name}, Email: {student.email}, age: {student.age}");
        }

        public static bool IsValidEmail(string email)
        {
            // Regular expression for email validation
            string emailPattern = @"^\S+@\S+\.\S+$";

            return Regex.IsMatch(email, emailPattern);
        }

        static void CreateCourse()
        {

        }
    }
}