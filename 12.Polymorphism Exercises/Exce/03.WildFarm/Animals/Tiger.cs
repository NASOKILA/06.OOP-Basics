using System;
using System.Collections.Generic;
using System.Text;


public class Tiger : Feline
{
    
    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion, breed)
    {
        EadableFoods.Add("Meat");
    }

    public double EatingIncrement { get; set; } = 1.00;

    public List<string> EadableFoods { get; set; } = new List<string>();

    public override string AskFood()
    {
        return $"ROAR!!!";
    }


}

