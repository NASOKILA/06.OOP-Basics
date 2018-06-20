using System;
using System.Collections.Generic;
using System.Text;


public class Tesla : IElectricCar
{
    public string Model { get; set; }

    public string Color { get; set; }

    public int Battery { get; set; }


    public Tesla()
    {}

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
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
         
        result.AppendLine($"{this.Color} {this.GetType()} {this.Model} with {this.Battery} Batteries");
        result.AppendLine($"{this.Start()}");
        result.AppendLine($"{this.Stop()}");

        return result.ToString();
        
    }
}

