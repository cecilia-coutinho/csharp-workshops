namespace NumbersGame
{
    internal class Program
    {
        private static int GetGuess()
        {
            int userNumberInt = 0;
            try
            {
                userNumberInt = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That's not a number");
                userNumberInt = GetGuess();
            }
            return userNumberInt;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! I think of a number. Can you guess which one? You get five attempts.");
            Console.WriteLine("Type a number: ");
            int tries = 5;
            int counter = 0;

            int randomNumber = new Random().Next(1, 20);

            while (counter <= 5)

            {
                int userNumberInt = GetGuess();
                counter++;

                if (userNumberInt == randomNumber)
                {
                    Console.WriteLine("You guessed right");
                    break;
                }

                if (randomNumber > userNumberInt)
                {
                    Console.WriteLine("Sorry you guessed too low!");
                }
                if (randomNumber < userNumberInt)
                {
                    Console.WriteLine("Sorry you guessed too high!\r\n");
                }
                if (tries == counter)
                {
                    Console.WriteLine("the number was: " + randomNumber);
                    Console.WriteLine("Unfortunately you failed to guess the number in five tries!");
                    break;
                }
            }
        }
    }
}