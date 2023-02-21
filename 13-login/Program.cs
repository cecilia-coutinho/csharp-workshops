using static System.Console; //to simplify Console references

namespace Login
{
    internal class Program
    {
        private static UserAccount[] usersAccount = {
            new UserAccount("maria", "1234"),
            new UserAccount("pedro", "1234"),
            new UserAccount("kalle", "1234"),
            new UserAccount("johan", "1234"),
            new UserAccount("matias", "1234") };

        // to get index of array of each user
        static int GeUserIndexByUserName(string? user)
        {
            for (int i = 0; i < usersAccount.Length; i++)
            {
                if (usersAccount[i].User == user)
                {
                    return i;
                }
            }

            return -1; //false
        }


        static void Main(string[] args)
        {
            RunLogin();
        }

        static void RunLogin()
        {
            Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t============WELCOME!============\n");
            Console.ResetColor();
            Console.Write("\n\tUser: \n\t");
            string? user = Console.ReadLine()?.ToLower();
            Console.Write("\n\tPassword: \n\t");
            string? password = Console.ReadLine();

            int userIndex = GeUserIndexByUserName(user); //get user index
            bool accountFound = userIndex != -1;

            if (accountFound)
            {
                if (usersAccount[userIndex].Password == password)
                {
                    bool runLoginMenu = true;
                    while (runLoginMenu)
                    {
                        Clear();
                        string welcome1 = "\n\t============Welcome!============\n";

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(welcome1.ToUpper());
                        Console.ResetColor();
                        Console.WriteLine("\tPlease select one of the options below:");
                        Console.WriteLine("\n\t1. First menu\n" +
                            "\n\t2. Second menu\n" +
                            "\n\t3. Third Menu\n" +
                            "\n\t4. Change your Password\n" +
                            "\n\t5. Log Out\n");
                        Console.Write("\t Select menu: ");

                        int menuChoice;
                        int.TryParse(Console.ReadLine(), out menuChoice);

                        switch (menuChoice)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine(welcome1.ToUpper());
                                Console.ResetColor();
                                GoBackMenuOptions();
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine(welcome1.ToUpper());
                                Console.ResetColor();
                                GoBackMenuOptions();
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine(welcome1.ToUpper());
                                Console.ResetColor();
                                GoBackMenuOptions();
                                break;
                            case 4:
                                ChangePassword(userIndex);
                                GoBackMenuOptions();
                                break;
                            case 5:
                                Console.WriteLine("\n\tThanks for your visit!");
                                Thread.Sleep(1000);
                                RunLogin();
                                break;
                            default:
                                Console.Clear();
                                InvalidOption();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\tPlease, choose 1-5 from the menu\n");
                                Console.ResetColor();
                                GoBackMenuOptions();
                                break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tInvalid password!\n".ToUpper());
                    Console.ResetColor();
                    GoBackMenuOptions();
                    RunLogin();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tInvalid username or password!\n".ToUpper());
                Console.ResetColor();
                GoBackMenuOptions();
                RunLogin();
            }
        }

        static void GoBackMenuOptions()
        {
            Console.WriteLine("\n\tPress ENTER to go back to the menu.\n");
            Console.ReadLine();
        }

        static void InvalidOption()
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tERROR: Invalid Option!".ToUpper());
            ResetColor();
        }

        static void ChangePassword(int userIndex)
        {
            Console.Write("\n\tType your new Password: ");
            string? passwordNewOne = Console.ReadLine();
            if (passwordNewOne != null)
            {
                usersAccount[userIndex].Password = passwordNewOne;
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tthe password was successfully changed!\n".ToUpper());
                ResetColor();
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tERROR! Password could not be changed");
                ResetColor();
            }
        }
    }
}
