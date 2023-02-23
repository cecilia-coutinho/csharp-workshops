using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop16DbCsharp
{
    internal class CourseModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int points { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }

        public static void GetAllCourses()
        {
            List<CourseModel> courses = PostgresDataAccess.GetAllCourses();

            if (courses != null && courses.Count > 0)
            {
                Console.WriteLine($"\n\tDet finns {courses.Count} kurser: ");
                foreach (var course in courses)
                {
                    string courseStart = ParseDateToString(course.start_date);
                    string courseEnd = ParseDateToString(course.end_date);

                    Console.WriteLine($"\n\t- Kurs: {course?.name?.ToUpper()}, {course?.points} points, " +
                        $"start: {courseStart}, slut: {courseEnd}");
                }
            }
            else
            {
                Console.WriteLine($"\tInga kurs hittades");
            }
        }
        public static void CreateCourse()
        {
            DateTime startDate, endDate;
            string? name, start, end;

            Console.Write("\n\tCourse name: ");
            name = Console.ReadLine()?.ToLower();
            Console.Write("\tType points: ");
            int.TryParse(Console.ReadLine(), out int points);
            Console.Write("\tType start date dd-MM-yyyy: ");
            start = Console.ReadLine();
            Console.Write("\tType end date dd-MM-yyyy: ");
            end = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || points <= 0 || string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tPlease enter a value for all required fields (name, points, start date, end date).");
                Console.ResetColor();
                return;
            }
            else
            {
                try
                {
                    startDate = ParseStringToDate(start);
                    endDate = ParseStringToDate(end);

                    CourseModel course = new CourseModel()
                    {
                        name = name,
                        points = points,
                        start_date = startDate,
                        end_date = endDate
                    };

                    PostgresDataAccess.CreateNewCourse(course);
                    Console.WriteLine($"\n\tNEW COURSE: name: {course.name}, Points: {course.points}, Start {ParseDateToString(course.start_date)}, End {ParseDateToString(course.end_date)}.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\n\tDate in wrong format: " + ex.Message);
                }
            }
        }

        static DateTime ParseStringToDate(string dateString)
        {
            string dateFormat = "dd-MM-yyyy"; //expected date format
            return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
        }

        static string ParseDateToString(DateTime date)
        {
            string dateFormat = "dd-MM-yyyy";
            string dateString = date.ToString(dateFormat);

            return dateString;
        }
    }
}
