﻿using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;

namespace Workshop16DbCsharp
{
    internal class PostgresDataAccess
    {
        // variable to store the connection string
        private static string connectionString = LoadConnectionString();

        private static string LoadConnectionString(string id = "Default")
        {
            // Return the connection string stored in the configuration file
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        // ###### Here starts CRUD operations ( Create, Retrieve, Update, and Delete) ######

        // Create student
        public static void CreateNewStudent(StudentModel student)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO csrc_student (first_name, last_name, email, age, password) " +
                             "VALUES (@first_name, @last_name, @email, @age, @password)";
                try
                {

                    connection.Execute(sql, student);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error creating student", ex);
                }

            }
        }

        // Retrieve student by ID
        public static StudentModel GetStudentById(int studentId)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM csrc_student WHERE id = @id";

                try
                {
                    return connection.QuerySingleOrDefault<StudentModel>(sql, new { id = studentId });
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting student by id", ex);
                }
            }
        }

        // Retrieve all users
        public static List<StudentModel> GetAllStudents()
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM csrc_student";

                try
                {
                    return connection.Query<StudentModel>(sql).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting a list of students", ex);
                }
            }
        }

        //Update student
        public static void UpdateStudent(StudentModel student)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE csrc_student SET " +
                             "first_name = @first_name, " +
                             "last_name = @last_name," +
                             "email = @email, " +
                             "age = @age, " +
                             "password = @password";

                //TO TRY LATER:
                //Use parameterized queries to prevent SQL injection attacks
                //var userParameters = new
                //{
                //    first_name = student.first_name,
                //    last_name = student.last_name,
                //    email = student.email,
                //    age = student.age,
                //    password = student.password
                //};

                try
                {
                    connection.Execute(sql, student);
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Ops! Something happened... Error updating student", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened...", ex);
                }
            }
        }
        // Delete student by ID
        public static void DeleteUser(int studentId)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM csrc_student WHERE id = @id";

                try
                {
                    // Execute the SQL statement with the given student ID parameter
                    connection.Execute(sql, new { id = studentId });
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error deleting user", ex);
                }
            }
        }

        // Create course
        public static void CreateNewCourse(CourseModel course)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO csrc_course (name, points, start_date, end_date) " +
                             "VALUES (@name, @points, @start_date, @end_date)";
                try
                {

                    connection.Execute(sql, course);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error creating user", ex);
                }

            }
        }
        // Retrieve all courses
        public static List<CourseModel> GetAllCourses()
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM csrc_course";

                try
                {
                    return connection.Query<CourseModel>(sql).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting a list of users", ex);
                }
            }
        }

        // Retrieve course by ID
        public static CourseModel GetCourseById(int courseId)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM csrc_course WHERE id = @id";

                try
                {
                    return connection.QuerySingleOrDefault<CourseModel>(sql, new { id = courseId });
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting user by id", ex);
                }
            }
        }

        // Update course

        public static void UpdateCourse(CourseModel course)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE csrc_course SET " +
                             "name = @name, " +
                             "points = @points," +
                             "start_date = @start_date, " +
                             "end_date = @end_date";
                try
                {
                    connection.Execute(sql, course);
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Ops! Something happened... Error updating user", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened...", ex);
                }
            }
        }

        // Delete course by ID
        public static void DeleteCourse(int courseId)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM csrc_course WHERE id = @id";

                try
                {
                    connection.Execute(sql, new { id = courseId });
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error deleting user", ex);
                }
            }
        }

    }
}