using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Cars
{
    public class Car
    {
        public const int tires = 4;

        public readonly int lights = 2;

        public Car()
        {
            this.lights = 4;
        }

        public void Start()
        {
            Console.WriteLine("{0} Started !", "Car");
        }
    }
}