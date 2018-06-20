using System;
using System.Collections.Generic;
using System.Text;


public class Hen : Bird
{
    

    public Hen(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, foodEaten, wingSize)
    {
        EadableFoods.Add("Vegetable");
        EadableFoods.Add("Fruit");
        EadableFoods.Add("Meat");
        EadableFoods.Add("Seeds");
    }

    public double EatingIncrement { get; set; } = 0.35;

    public List<string> EadableFoods { get; set; } = new List<string>();

    public override string AskFood()
    {
        return $"Cluck";
    }

}

