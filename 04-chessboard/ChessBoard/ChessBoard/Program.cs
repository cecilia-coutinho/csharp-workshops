using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace ChessBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Chess Board!");
            Console.Write("How large the board? Please, type a number: ");
            string userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int value);
            printBoard(value, value);
        }

        static void printBoard(int rowSize, int columnSize)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < columnSize; col++)
                {
                    //even
                    if ((row + col) % 2 == 0)
                    {
                        Console.Write("■ ");
                    }
                    //odd
                    else
                    {
                        Console.Write("□ ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}