namespace OOPPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(4);
            Triangle triangle = new Triangle(4, 5);
            Circle circle = new Circle(4);
            Rectangle rectangle = new Rectangle(4, 7);

            Console.WriteLine($"Square Area: {square.Area()};\nTriangle Area: {triangle.Area()};\nCircle Area: {circle.Area()};\nRectangle Area: {rectangle.Area()};");
        }
    }
}