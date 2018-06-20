using System;
using System.Collections.Generic;
using System.Text;


public class Mouse : Mammal
{
    
    public Mouse(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion)
    {
        EadableFoods.Add("Fruit");
        EadableFoods.Add("Vegetable");
    }


    public double EatingIncrement { get; set; } = 0.10;

    public List<string> EadableFoods { get; set; } = new List<string>();

    public override string AskFood()
    {
        return $"Squeak";
    }
}

