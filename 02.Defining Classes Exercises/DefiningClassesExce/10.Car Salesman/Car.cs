using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{

    public Car()
    {}

    public string Model { get; set; }

    public Engine Engine { get; set; }

    public string Weight { get; set; }

    public string Color { get; set; }


    public override string ToString()
    {
        
        return $"{Model}:" + Environment.NewLine
             + $"{Engine.ToString()}" + Environment.NewLine
             + $"  Weight: {Weight}" + Environment.NewLine
             + $"  Color: {Color}";

    }
}

