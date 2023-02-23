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
            //Helper.TestCreatingNewStudent();
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
                        StudentModel.GetAllStudents();
                        GoBackMenuOptions();
                        break;
                    case 2:
                        //2. Lista kurser
                        Console.Clear();
                        CourseModel.GetAllCourses();
                        GoBackMenuOptions();
                        break;
                    case 3:
                        //3. Skapa student
                        Console.Clear();
                        StudentModel.CreateStudent();
                        GoBackMenuOptions();
                        break;
                    case 4:
                        //4. Skapa kurs
                        Console.Clear();
                        CourseModel.CreateCourse();
                        GoBackMenuOptions();
                        break;
                    case 5:
                        //5. Byt lösenord
                        Console.Clear();
                        StudentModel.UpdatePassword();
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
    }
}