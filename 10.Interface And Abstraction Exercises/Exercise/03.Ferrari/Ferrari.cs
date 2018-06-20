using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : ICar
{
    public string Model => "488-Spider";

    public string Driver { get; set; } 

    public string Accelerate()
    {
        return "Zadu6avam sA!";
    }

    public string Break()
    {
        return "Brakes!";
    }
    
    public Ferrari()
    {}

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Break()}/{this.Accelerate()}/{this.Driver}";
    }


}

