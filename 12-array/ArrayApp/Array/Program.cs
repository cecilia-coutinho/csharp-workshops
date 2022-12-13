namespace Array
{
    internal class Program
    {
        //Single-Dimensional Arrays
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t==================WELCOME!==================\n");
            Console.ResetColor();

            //declare an array with the user input amount of integers:
            Console.WriteLine("\n\tHow many integers do you want to store in the array? ");
            Console.Write("\t ");
            int amountArray;
            int.TryParse(Console.ReadLine(), out amountArray);

            if (amountArray > 0)
            {
                //declare array values
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\tEnter {amountArray} integers: ");
                Console.ResetColor();

                int counter = 1;
                while (counter <= amountArray)
                {
                    string? userValuesArray = " ";

                    //list to storage user values
                    List<int> values = new List<int>();

                    for (counter = 1; counter <= amountArray; counter++)
                    {
                        Console.Write($"\n\tType {AddOrdinal(counter)} integer: ");
                        userValuesArray = Console.ReadLine();

                        //to add user values to a list
                        int aValue;
                        int.TryParse(userValuesArray, out aValue);
                        values.Add(aValue);
                    }

                    //element type of array: integer
                    int[] userArrayInt = new int[amountArray];

                    //add list values to array
                    userArrayInt = values.ToArray();


                    // print array values
                    PrintResult(userArrayInt);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tERROR!Invalid!" +
                "\n\tInput needs to be a number and higher than 0\n");
                Console.ResetColor();
                Console.WriteLine("\n\tPress ENTER to EXIT\n");
                Console.ReadLine();
            }
        }

        static void PrintResult(int[] userArrayInt)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t=========YOUR ARRAY=========");
            for (int i = 0; i < userArrayInt.Length; i++)
            {
                Console.WriteLine($"\n\tIndex {i}: {userArrayInt[i]}");
            }
            Console.WriteLine("\n\t============================");
            Console.ResetColor();
            Console.WriteLine("\n\tPress ENTER to EXIT\n");
            Console.ReadLine();
        }

        //to transform cardinal numbers to ordinal
        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }
    }
}