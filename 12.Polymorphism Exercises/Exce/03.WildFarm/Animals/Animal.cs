using System;
using System.Collections.Generic;
using System.Text;


public abstract class Animal
{

    public Animal()
    {}

    public Animal(string name, double weight, int foodEaten)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = FoodEaten;
    }

    public string Name { get; set; }

    public double Weight { get; set; }

    public int FoodEaten { get; set; }
    

    public abstract string AskFood();


    public override string ToString()
    {
        return base.ToString();
    }
}

