namespace FizzBuzz;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to FizzBuzz");
        Console.Write("Please, type a number: ");
        string userInput = Console.ReadLine();
        bool numberInput = int.TryParse(userInput, out int value);
        RunFizzBuzz(value);
    }

    static void RunFizzBuzz(int value)
    {
        for (int i = 1; i <= value; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine(i + ": FizzBuzz");
            }

            else if (i % 5 == 0)
            {
                Console.WriteLine(i + ": Buzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine(i + ": Fizz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}