using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphism
{
    internal class Triangle : Geometri
    {
        public double Height;
        public double BaseTriangle;

        public Triangle(double height, double baseTriangle) : base(height, baseTriangle)
        {
            Height = height;
            BaseTriangle = baseTriangle;
        }

        public override double Area()
        {
            return (BaseTriangle * Height) / 2;
        }
    }
}
