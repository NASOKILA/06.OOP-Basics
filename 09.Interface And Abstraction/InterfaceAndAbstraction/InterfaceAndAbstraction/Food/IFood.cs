using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Food
{
    public interface IFood
    {
        string Name { get; set; }

        decimal Price { get; }

        decimal Weight { get; }

        void Information();
    }
}
