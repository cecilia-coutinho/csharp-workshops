using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphism
{
    internal class Circle : Geometri
    {
        public double Radius { get; set; }
        public Circle(double radius) : base(radius, radius)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return PI * Radius * Radius;
        }
    }
}
