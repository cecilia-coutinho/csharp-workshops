using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphism
{
    internal class Rectangle : Geometri
    {
        public double Lenght;
        public double Breadth;

        public Rectangle(double lenght, double breadth) : base(lenght, breadth)
        {
            Lenght = lenght;
            Breadth = breadth;
        }

        public override double Area()
        {
            return Lenght * Breadth;
        }
    }
}
