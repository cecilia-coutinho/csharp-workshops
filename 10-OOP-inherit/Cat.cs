using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
    public class Cat : Animals
    {
        public Cat(string catName) : base(catName)
        {
            this.Legs = 4;
            this.Sounds = "'MEAW MEAW!'";
            this.EatFood = "Pork, chicken and beef";
        }
    }

    public class MyCat : Cat
    {
        string MyCatName = string.Empty;
        string MyCatType = string.Empty;
        public MyCat(string catName, string catType) : base(catName)
        {
            this.MyCatName = catName;
            this.MyCatType = catType;

        }

        public void MyCatIntroduction()
        {
            Console.WriteLine($"\n\tI have a {MyCatType} cat and his name is {MyCatName}\n");
        }
    }
}
