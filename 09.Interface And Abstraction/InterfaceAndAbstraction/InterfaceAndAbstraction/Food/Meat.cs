using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Food
{

    //ZADULJITELNO TRQBVA DA GO IMPLEMENTIRAME avtomatochno VU VSEKI KLAS KOITO SHTE GO POLZVA !!!
    public class Meat : IFood
    {
        public string Name { get; set; }

        public decimal Price { get; private set; }

        public decimal Weight { get; private set; }

        public Meat(string name, decimal price, decimal weight)
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
