using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Cars
{
    public class Fiat : Car
    {
        public new void Start()
        {
            Console.WriteLine("Fiat started !");
        }
    }
}
