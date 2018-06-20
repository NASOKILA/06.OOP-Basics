using System;
using System.Collections.Generic;
using System.Text;


public class Seat : ICar
{
    public string Model { get; set; }
    public string Color { get; set; }

    public Seat()
    {}

    public Seat(string model, string color)
    {
        this.Color = color;
        this.Model = model;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        
        result.AppendLine($"{this.Color} {this.GetType()} {this.Model}");
        result.AppendLine($"{this.Start()}");
        result.AppendLine($"{this.Stop()}");
        
        return result.ToString();
    }

}

