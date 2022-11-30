using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
    public class Dog : Animals
    {
        string Type = string.Empty;
        public Dog(string dogName) : base(dogName)
        {
            this.Legs = 4;
            this.Sounds = "'AW AW!'";
            this.EatFood = "Beef";
        }

        public void FavoriteDogType(string type)
        {
            this.Type = type;
            Console.WriteLine($"\n\tMy favorite dog type is {Type}.\n");

            Console.Write("\n\tWhich type of dog is your favorite?: ");
            string? favoriteDogType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\tOwww! {favoriteDogType} is very cool!\n");
            Console.ResetColor();
        }
    }
}
