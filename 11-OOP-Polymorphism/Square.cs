using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphism
{
    internal class Square : Geometri
    {
        public double Side;

        public Square(double side) : base(side, side)
        {
            Side = side;
        }

        public override double Area()
        {
            return Side * Side;
        }
    }
}
