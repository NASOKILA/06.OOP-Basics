using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    //Nasledqva interfeisa IArms
    public interface IPistols : IArms
    {
        string Model { get; set; }

        string Origin { get; set; }
    }
}
