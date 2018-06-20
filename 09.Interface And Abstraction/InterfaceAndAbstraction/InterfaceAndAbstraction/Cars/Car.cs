using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Cars
{
    public class Car
    {
        //ne moje da se promenq
        public const int tires = 4;

        //moje da se promenq samo ot konstruktura
        public readonly int lights = 2;

        public Car()
        {
            this.lights = 4;
            //this.tires = 6;    //vuobshte ne ni dava da go dostupim
        }


        public void Start()
        {
            Console.WriteLine("{0} Started !", "Car");
        }

    }
}
