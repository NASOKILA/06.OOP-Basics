using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    //NASLEDQVA DVA INTERFEISA
    public class ButterflyKnive : IArms, IKnives
    {
        
        public string Name { get; set; }

        public int Bullets { get; set; }

        public double Weight{ get; set; }

        public int SizeInCM { get; set; }

        public string Color { get; set; }

        public ButterflyKnive(string name, int bullets, double weight, int sizeInCm, string color)
        {
            this.Name = name;
            this.Bullets = bullets;
            this.Weight = weight;
            this.SizeInCM = sizeInCm;
            this.Color = color;
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
