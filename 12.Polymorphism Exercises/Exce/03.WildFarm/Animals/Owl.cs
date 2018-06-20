using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    
    public Owl(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, foodEaten, wingSize)
    {
        EadableFoods.Add("Meat");
    }

    public double EatingIncrement { get; set; } = 0.25;

    public List<string> EadableFoods { get; set; } = new List<string>();
    
    public override string AskFood()
    {
        return $"Hoot Hoot";
    }

    
}

