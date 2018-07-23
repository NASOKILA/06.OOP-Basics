using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Cars
{
    public class Opel : Car
    {
        public new void Start() {
            Console.WriteLine("Opel started !");
        }
    }
}
