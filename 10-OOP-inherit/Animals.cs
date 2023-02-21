using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
    public class Animals
    {
        public string Name { get; set; } = string.Empty;
        public int Legs { get; set; }
        public string Sounds { get; set; } = string.Empty;

        public string EatFood { get; set; } = string.Empty;

        public Animals(string animalName)
        {
            this.Name = animalName;
        }

        public void AnimalIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n\t{this.Name.ToUpper()} has {this.Legs} legs and says {this.Sounds}. The favorite food is {this.EatFood}.\n");
            Console.ResetColor();
        }
    }
}
