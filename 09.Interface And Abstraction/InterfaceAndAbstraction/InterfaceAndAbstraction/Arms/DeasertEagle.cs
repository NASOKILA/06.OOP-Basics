using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    //Nasledqva interfeisa IPistol koito nasledqva IArms
    class DeasertEagle : IPistols
    {
        public string Name { get; set; }

        public int Bullets { get; set; }

        public double Weight { get; set; }

        public string Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Origin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string PrintInfo()
        {
            return
                  $"Name: {Name} - " +
                  $"Bullets: {Bullets} - " +
                  $"Weight: {Weight}";
        }
    }
}
