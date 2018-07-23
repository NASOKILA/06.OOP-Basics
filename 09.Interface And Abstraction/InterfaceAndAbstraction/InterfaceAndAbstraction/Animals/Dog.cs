using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Animals
{
    public class Dog: Animal
    {

        public override void Sound()
        {
            Console.WriteLine("Bau Bau !");
        }

        public new void Eat() {
            base.Eat();
        }
    }
}