using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Workshop16DbCsharp
{
    internal class StudentModel
    {
        public int id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public int age { get; set; }
        public string? password { get; set; }

        public static void GetAllStudents()
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

        public static void CreateStudent()
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

            StudentModel student = new StudentModel()
            {
                first_name = firstName,
                last_name = lastName,
                email = email,
                age = age,
                password = password
            };
            PostgresDataAccess.CreateNewStudent(student);
            Console.WriteLine($"\n\tNEW STUDENT: name: {student.first_name} {student.last_name}, Email: {student.email}, age: {student.age}");
        }

        static bool IsValidEmail(string email)
        {
            // Regular expression for email validation
            string emailPattern = @"^\S+@\S+\.\S+$";

            return Regex.IsMatch(email, emailPattern);
        }
    }
}
