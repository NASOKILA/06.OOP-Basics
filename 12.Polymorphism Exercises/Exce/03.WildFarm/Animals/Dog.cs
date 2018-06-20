using System;
using System.Collections.Generic;
using System.Text;


public class Dog : Mammal
{
    
    public Dog(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion)
    {
        EadableFoods.Add("Meat");
    }
    
    public double EatingIncrement { get; set; } = 0.40;

    public List<string> EadableFoods { get; set; } = new List<string>();

    public override string AskFood()
    {
        return $"Woof!";
    }

    /*
    public override string ToString()
    {
        return $"{} [{}, {}, {}, {}]"; 
    }*/
}

