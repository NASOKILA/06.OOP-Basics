using System;

namespace _01.ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal length = decimal.Parse(Console.ReadLine());
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            Console.WriteLine(box.SurfaceArea());
            Console.WriteLine(box.LateralSurfaceArea());
            Console.WriteLine(box.Volume());
        }
    }
}

