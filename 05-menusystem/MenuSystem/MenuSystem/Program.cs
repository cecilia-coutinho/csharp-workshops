using System;
using System.Diagnostics;

namespace MenuSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            AdminMyMenu(); //call method
        }

        //Admin menu and features
        static void AdminMyMenu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.WriteLine("\n\tWelcome to my project collection! Please select one of the options below:");
                Console.WriteLine("\n\t1. Hello World\n" +
                    "\n\t2. Guess a Number\n" +
                    "\n\t3. Chess board\n" +
                    "\n\t4. Rock Paper Scissors Project\n" +
                    "\n\t5. Link to my Github\n" +
                    "\n\t6. Close\n");
                Console.Write("\t Select menu: ");
                int menuChoice;
                int.TryParse(Console.ReadLine(), out menuChoice);

                switch (menuChoice)
                {
                    case 1:
                        HelloWorldProject();
                        break;
                    case 2:
                        GuessNumberProject();
                        break;
                    case 3:
                        ChessBoardProject();
                        break;
                    case 4:
                        RockPaperScissorsProject();
                        //Console.Clear();
                        break;
                    case 5:
                        MyGithub();
                        break;
                    case 6:
                        Console.WriteLine("\n\tThanks for your visit!");
                        Thread.Sleep(1000);
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("\n\tChoose 1-6 from the menu");
                        break;
                }
                Console.Clear();
            }
        }

        static void HelloWorldProject()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = @"..\..\..\..\..\..\01-hello-world\MyFirstProgram\bin\Debug\net6.0\MyFirstProgram.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

        }

        static void GuessNumberProject()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = @"..\..\..\..\..\..\02-guess-number\NumbersGame\bin\Debug\net6.0\NumbersGame.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        static void ChessBoardProject()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = @"..\..\..\..\..\..\04-chessboard\ChessBoard\ChessBoard\bin\Debug\net6.0\ChessBoard.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

        }

        static void RockPaperScissorsProject()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = @"..\..\..\..\..\..\06-rock-paper-scissor\RockPaperScissors\bin\Debug\net6.0\RockPaperScissors.exe";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

        }

        static void MyGithub()
        {
            Console.WriteLine("\n\tMy Github Page:" + "\n\thttps://github.com/cecilia-coutinho\n");
            Console.WriteLine("\n\tclick ENTER to restart menu options.");
            Console.ReadLine();

        }
    }
}