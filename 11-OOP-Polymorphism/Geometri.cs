using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPolymorphism
{
    internal class Geometri
    {
        public double PI = Math.PI;
        protected double _xElement, _yElement;

        public Geometri(double xElement, double yElement)
        {
            _xElement = xElement;
            _yElement = yElement;
        }


        // virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class
        public virtual double Area()
        {
            return PI * _xElement * _yElement;
        }
    }
}
