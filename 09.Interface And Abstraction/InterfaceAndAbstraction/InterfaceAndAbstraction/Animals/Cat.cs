using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Animals
{
    public class Cat: Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Meow Meow !");
        }

        public void Sleep() 
		{}
    }
}