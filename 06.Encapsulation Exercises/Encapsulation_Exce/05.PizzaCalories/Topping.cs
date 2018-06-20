using System;
using System.Collections.Generic;
using System.Text;


public class Topping
{

    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const int DEFAULT_MULTIPLIER = 2;

    private Dictionary<string, decimal> validTypes = new Dictionary<string, decimal>()
    {
        ["Meat"] = (decimal)1.2,
        ["Veggies"] = (decimal)0.8,
        ["Cheese"] = (decimal)1.1,
        ["Sauce"] = (decimal)0.9

    };


    private decimal weight;
    private string toppingType;

    //IMA SAMO GETTER
    private decimal TypeMultiplier => validTypes[this.ToppingType];

    //IMA SAMO GETTER I E PUBLIC 
    public decimal Calories => DEFAULT_MULTIPLIER * this.Weight * TypeMultiplier;



    public string ToppingType
    {
        get { return toppingType; }
        set
        {
            if (!validTypes.ContainsKey(value))
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");

            toppingType = value;
        }
    }


    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");

            weight = value;
        }
    }

    public Topping()
    {}


    public Topping(string toppingType, decimal toppingWeight)
    {
        this.ToppingType = toppingType;
        this.Weight = toppingWeight;
    }

    

}

