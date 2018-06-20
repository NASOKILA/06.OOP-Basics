using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    public interface IArms
    {
        string Name { get; set; }

        int Bullets { get; set; }

        double Weight { get; set; }

        string PrintInfo();    
       
    }
}
