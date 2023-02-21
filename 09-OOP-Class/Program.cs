namespace OOPClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Console.WriteLine("A = " + circle.GetArea() + " || " + "C = " + circle.GetCircunference() + " || " + "D = " + circle.GetDiameter());

            Circle circle2 = new Circle(6);
            Console.WriteLine("A = " + circle2.GetArea() + " || " + "C = " + circle2.GetCircunference() + " || " + "D = " + circle2.GetDiameter());

            Triangle triangle = new Triangle(22, 25);
            Console.WriteLine("\nTRiangle:\n");
            Console.WriteLine("A = " + triangle.GetAreaTriangle());

        }
    }

    public class Circle
    {
        public int Radius;
        public double PI = Math.PI;

        public Circle(int radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            var area = PI * Radius * Radius;
            return area;

        }

        public double GetCircunference()
        {
            var circunference = 2 * PI * Radius;
            return circunference;
        }

        public double GetDiameter()
        {
            var diameter = 2 * Radius;
            return diameter;
        }
    }

    public class Triangle
    {
        public double Height;
        public double BaseTriangle;

        public Triangle(double height, double baseTriangle)
        {
            Height = height;
            BaseTriangle = baseTriangle;
        }

        public double GetAreaTriangle()
        {
            //Area = base X height / 2
            var areaTriangle = (BaseTriangle * Height) / 2;
            return areaTriangle;
        }
    }
}