using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdminMyGame();
        }

        static void AdminMyGame()
        {
            Console.WriteLine("\nWelcome to Rock Scissors Paper!");

            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("\n\t1. New Round\n" +
                    "\t2. Close");
                Console.Write("\tChoose menu: ");
                int menuChoice;
                int.TryParse(Console.ReadLine(), out menuChoice);

                switch (menuChoice)
                {
                    case 1:
                        playGame();
                        break;
                    case 2:
                        Console.WriteLine("\n\tThanks for your visit!");
                        Thread.Sleep(1000);
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("\n\tChoose 1-2 from the menu");
                        break;

                }
            }
        }

        static void playGame()
        {

            Console.Write("\nHow many rounds do you like?: ");
            int numberOfRounds = Convert.ToInt32(Console.ReadLine());

            string[] chances = new string[3] { "ROCK", "PAPER", "SCISSORS" }; // game choices
            Random randomChance = new Random(); // Creates an instance of the Random class for our random number
            int playerScore = 0;
            int computerScore = 0;

            for (int i = 0; i < numberOfRounds; i++)
            {

                Console.WriteLine(
                    "\nPaper\n" +
                    "Rock\n" +
                    "Scissors\n"
                    );
                Console.Write("\nwhat do you choose? Type your choice: ");
                string playerInput = Console.ReadLine().ToUpper();
                //int playerInput = Convert.ToInt32(Console.ReadLine());

                int randomNumbers = randomChance.Next(0, 3); //gives a random
                string computerInput = chances[randomNumbers]; //random inside array options

                //tie check
                if (playerInput == computerInput)
                {
                    Console.WriteLine($"The computer choose {computerInput}");
                    Console.WriteLine($"Is a tie");
                }

                //rock check
                else if (playerInput == "ROCK")
                {
                    if (computerInput == "SCISSORS")
                    {
                        Console.WriteLine($"The computer choose {computerInput}");
                        Console.WriteLine($"You Win, ROCK beats scissors!");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine($"The computer choose {computerInput}");
                        Console.WriteLine($"You Lost!");
                        computerScore++;
                    }
                }

                //paper check
                else if (playerInput == "PAPER")
                {
                    if (computerInput == "ROCK")
                    {
                        Console.WriteLine($"The computer choose {computerInput}");
                        Console.WriteLine($"You Win, PAPER beats ROCK!");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine($"The computer choose {computerInput}");
                        Console.WriteLine($"You Lost!");
                        computerScore++;
                    }
                }

                //Scissors check
                else if (playerInput == "SCISSORS")
                {
                    if (computerInput == "PAPER")
                    {
                        Console.WriteLine($"The computer choose {computerInput}");
                        Console.WriteLine($"You Win, SCISSORS beat PAPER!");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine($"The computer choose {computerInput}");
                        Console.WriteLine($"You Lost!");
                        computerScore++;
                    }
                }

                else
                {
                    Console.WriteLine("You must choose rock,paper or scissors!");

                }
            }
            Console.WriteLine($"Player Score: {playerScore}");
            Console.WriteLine($"Computer Score: {computerScore}");
            CheckWinner(playerScore, computerScore, numberOfRounds);

        }

        static void CheckWinner(int playerScore, int computerScore, int numberOfRounds)
        {
            if (playerScore > computerScore)
            {
                Console.WriteLine("You won the game! Congratulations!");
            }
            else
            {
                Console.WriteLine("Game Over, you lost! Try again next time!");
            }
        }
    }


}
