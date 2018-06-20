using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    public class Pistol : IArms
    {
        public string Name { get; set; }

        public int Bullets { get; set; }

        public double Weight { get; set; }

        public Pistol(string name, int bullets, double weight)
        {
            this.Name = name;
            this.Bullets = bullets;
            this.Weight = weight;
        }

        public string PrintInfo()
        {
            return 
                  $"Name: {Name} - " +
                  $"Bullets: {Bullets} - " +
                  $"Weight: {Weight}";
        }
    }
}
