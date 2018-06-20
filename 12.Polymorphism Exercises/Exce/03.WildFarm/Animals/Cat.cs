using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Feline
{
    
    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion, breed)
    {
        EadableFoods.Add("Vegetable");
        EadableFoods.Add("Meat");
    }

    public List<string> EadableFoods { get; set; } = new List<string>();

    public double EatingIncrement { get; set; } = 0.30;

    public override string AskFood()
    {
        return $"Meow";
    }
    


}

