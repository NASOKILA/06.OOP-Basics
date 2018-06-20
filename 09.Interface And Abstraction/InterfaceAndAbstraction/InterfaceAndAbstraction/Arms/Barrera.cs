using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    //Nasledqva IPistols koito nasledqva IArms
    public class Barrera : IPistols
    {
        public string Model { get; set; }

        public string Origin { get; set; }

        public string Name { get; set; }

        public int Bullets { get; set; }

        public double Weight { get; set; }

        public Barrera(string model, string origin, string name, int bullets, double weight)
        {
            this.Model = model;
            this.Origin = origin;
            this.Name = name;
            this.Bullets = bullets;
            this.Weight = weight;
        }

        public string PrintInfo()
        {
            return $"Model: {Model} - " +
                $"Origin: {Origin} - " +
                $"Name: {Name} - " +
                $"Bullets: {Bullets} - " +
                $"Weight: {Weight}";
        }
    }
}
