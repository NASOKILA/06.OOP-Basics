using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int[] points = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int x1 = points[0];
        int y1 = points[1];
        int x2 = points[2];
        int y2 = points[3];

        Point top = new Point(x1, y1);
        Point bottom = new Point(x2, y2);

        Rectangle square = new Rectangle(top, bottom);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] currentPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int x = currentPoints[0];
            int y = currentPoints[1];

            Point point = new Point(x, y);

            bool result = square.Contains(point);
            Console.WriteLine(result);
        }
    }
}