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
            StudentModel student = new StudentModel()
            {
                first_name = "marta",
                last_name = "rosa",
                email = "martarosa@tester.com",
                age = 23,
                password = "1234"
            };
            PostgresDataAccess.CreateNewStudent(student);
            Console.WriteLine($"name: {student.first_name} {student.last_name}, Email: {student.email}, age: {student.age}");
        }

    }
}
