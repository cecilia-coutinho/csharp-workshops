using System;

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
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("coming soon");
                        Console.ResetColor();
                        GoBackMenuOptions();
                        break;
                    case 0:
                        Console.WriteLine("\n\tThanks for your visit!");
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