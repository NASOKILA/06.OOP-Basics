using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Animals
{
    public abstract class Animal
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public abstract void Sound();

        public void Eat() {
            Console.WriteLine("I am eating !");
        }
    }
}
