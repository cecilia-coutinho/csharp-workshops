using Npgsql;
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

        //method that returns a tuple
        static (bool Success, string? ErrorMessage, CourseModel? course) CourseDataInput()
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
                return (false, "\n\tPlease enter a value for all required fields (name, points, start date, end date", null);
            }
            else
            {
                try
                {
                    startDate = ParseStringToDate(start);
                    endDate = ParseStringToDate(end);

                    CourseModel? newCourse = new CourseModel()
                    {
                        name = name,
                        points = points,
                        start_date = startDate,
                        end_date = endDate
                    };
                    return (true, null, newCourse);
                }
                catch (FormatException ex)
                {
                    string invalidFormat = "\n\tDate in wrong format: " + ex.Message;
                    return (false, invalidFormat, null);
                }
            }
        }
        public static void CreateCourse()
        {
            (bool success, string? errorMessage, CourseModel? course) = CourseDataInput(); //method that returns a tuple

            if (success && course != null)
            {

                PostgresDataAccess.CreateNewCourse(course);
                Console.WriteLine($"\n\tNEW COURSE: name: {course.name}, Points: {course.points}, Start {ParseDateToString(course.start_date)}, End {ParseDateToString(course.end_date)}.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ResetColor();
            }
        }

        public static void UpdateCourse()
        {
            string? name, start;

            Console.Write("\n\tcourse name: ");
            name = Console.ReadLine();
            Console.Write("\n\tstart date dd-MM-yyyy: ");
            start = Console.ReadLine();

            //retrive data by name
            CourseModel? course = PostgresDataAccess.GetCourseByname(name);

            if (name == null || start == null || course == null)
            {
                Console.WriteLine("\n\tCourse not found");
                return;
            }

            try
            {
                DateTime startDate = ParseStringToDate(start);
                if (course.start_date != startDate)
                {
                    Console.WriteLine("\n\tDate doesn't match");
                    return;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n\tInvalid date format", ex);
                return;
            }

            Console.WriteLine("\n\tType the new data\n");
            (bool success, string? errorMessage, CourseModel? updatedCourse) = CourseDataInput(); //method that returns a tuple

            if (success && updatedCourse != null)
            {
                updatedCourse.id = course.id; //set same id
                PostgresDataAccess.UpdateCourse(updatedCourse);
                Console.WriteLine($"\n\tCOURSE UPDATED: name: {updatedCourse.name}, Points: {updatedCourse.points}, Start {ParseDateToString(updatedCourse.start_date)}, End {ParseDateToString(updatedCourse.end_date)}.");
            }
            else
            {
                Console.WriteLine(errorMessage);
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
