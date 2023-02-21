using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop16DbCsharp
{
    internal class Helper
    {

        public static void TestCreatingNewStudent()
        {
            StudentModel student = new StudentModel();
            {
                student.first_name = "ignacio";
                student.last_name = "rosa";
                student.email = "nachorosa@tester.com";
                student.age = 33;
                student.password = "1234";
            };
            PostgresDataAccess.CreateNewStudent(student);
            Console.WriteLine($"name: {student.first_name} {student.last_name}, Email: {student.email}, age: {student.age}");
        }

    }
}
