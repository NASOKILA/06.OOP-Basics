using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Arms
{
    public interface IKnives : IArms
    {
        int SizeInCM { get; set; }
        string Color { get; set; }
    }
}
