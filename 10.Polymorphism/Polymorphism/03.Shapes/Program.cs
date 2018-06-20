using System;

namespace _03.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(5, 5); // polimorphism
            Shape circle = new Circle(5); // polimorphism

            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.Draw());

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

        }
    }
}
