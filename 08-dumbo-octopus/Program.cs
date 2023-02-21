namespace DumboOctopus
{
    internal class DetectFlashed
    {
        static void Main(string[] args)
        {
            int[,] octopus = new int[10, 10]
{
                { 5, 4, 8, 3, 1, 4, 3, 2, 2, 3},
                { 2, 7, 4, 5, 8, 5, 4, 7, 1, 1},
                { 5, 2, 6, 4 ,5, 5, 6, 1, 7 ,3},
                { 6, 1, 4, 1, 3, 3, 6, 1, 4, 6},
                { 6, 3, 5, 7, 3, 8, 5, 4, 7, 8},
                { 4, 1, 6, 7, 5, 2, 4, 6, 4, 5},
                { 2, 1, 7, 6, 8, 4, 1, 7, 2, 1},
                { 6, 8, 8, 2, 8, 8, 1, 1, 3, 4},
                { 4, 8, 4, 6, 8, 4, 8, 5, 5, 4},
                { 5, 2, 8, 3, 7, 5, 1, 5, 2, 6}
};

            Console.WriteLine("==========Welcome to Dumbo Octopus!==========");
            Console.WriteLine("How many steps?: ");
            Console.Write("");
            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);
            for (int step = 0; step <= userInput; step++)
            {
                Console.WriteLine($"\nStep Number: {step + 1}");
                octopus = NewOctopusForIncreaseEnergy(octopus);
                var flashed = DetectFlash(octopus);
                octopus = ResetFlashed(octopus, flashed);
                PrintBoard(octopus);
                //foreach (var tuple in flashed)
                //{
                //    Console.WriteLine("{0} - {1}", tuple.Item1, tuple.Item2);
                //}
            }
        }

        static int[,] NewOctopusForIncreaseEnergy(int[,] octopus)
        {
            int rowSize = octopus.GetLength(0);
            int colSize = octopus.GetLength(1);

            int[,] newOctopus = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    newOctopus[row, col] = octopus[row, col] + 1;
                }
            }
            return newOctopus;
        }

        static void PrintBoard(int[,] octopus)
        {
            int rowSize = octopus.GetLength(0);
            int colSize = octopus.GetLength(1);

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    Console.Write(octopus[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        //energy level greater than 9 flashes
        static List<Tuple<int, int>> DetectFlash(int[,] octopus)
        {
            int rowSize = octopus.GetLength(0);
            int colSize = octopus.GetLength(1);

            int[,] newOctopus = new int[rowSize, colSize];
            var flashedList = new List<Tuple<int, int>>();

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    if (octopus[row, col] > 9)
                    {
                        //flash!
                        flashedList.Add(new Tuple<int, int>(row, col));
                    }
                }
            }
            return flashedList;
        }

        static int[,] ResetFlashed(int[,] octopus, List<Tuple<int, int>> flashed)
        {
            int rowSize = octopus.GetLength(0);
            int colSize = octopus.GetLength(1);

            int[,] newOctopus = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    Tuple<int, int> current = new Tuple<int, int>(row, col);
                    if (flashed.Contains(current))
                    {
                        newOctopus[row, col] = 0;
                    }
                    else
                    {
                        newOctopus[row, col] = octopus[row, col];
                    }
                }
            }
            return newOctopus;
        }

        //TO DO: near +1
        static void FindAdjacent(int[,] octopus)
        {

        }
    }
}