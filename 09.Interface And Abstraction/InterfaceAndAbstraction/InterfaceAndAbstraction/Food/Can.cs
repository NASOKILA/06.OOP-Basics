using System;
using System.Collections.Generic;
using System.Text;


//MOJEM DA VKLUCHIM I 'Animals'
using InterfaceAndAbstraction.Animals;

namespace InterfaceAndAbstraction.Food
{
    public class Can : IFood
    {
        public string Name { get; set; }

        public decimal Price { get; private set; }

        public decimal Weight { get; private set; }

        public Can(string name, decimal price, decimal weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }


        public void Information()
        {
            Console.WriteLine($"Name: {this.Name} / Price: {this.Price} / Weight: {this.Weight}");
        }
    }
}
