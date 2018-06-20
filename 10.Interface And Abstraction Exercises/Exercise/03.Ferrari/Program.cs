using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string driverName = Console.ReadLine();

        Ferrari ferrari = new Ferrari(driverName);

        Console.WriteLine(ferrari.ToString());
    }
}

