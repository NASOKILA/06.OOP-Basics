using System;

namespace _03.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(5, 5);
            Shape circle = new Circle(5); 

            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.Draw());

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}