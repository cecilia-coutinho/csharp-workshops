namespace MyFirstProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Elevsnamn: Cecilia S. R. Coutinho
            //class: NET22

            //create a number
            int myNum = 11;
            Console.WriteLine($"My number is: {myNum}\n");

            //if number is hight than my number
            if (myNum > 10)
            {
                Console.WriteLine("\"Talet är stort!\" ");
            }
            else
            {
                Console.WriteLine("Oj. Lågt tal!");
            }

            //name input
            Console.WriteLine("\nWhat's your name?: ");
            string? userName = Console.ReadLine();
            Console.WriteLine($"Hej {userName}!");

            //for loop to print numbers sequency on the screen
            Console.WriteLine("Loop that prints all the numbers from zero up to 'My number'");
            for (int i = 0; i < myNum; i++)
            {
                Console.WriteLine(i);

            }
        }
    }
}