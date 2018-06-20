using System;
using System.Collections.Generic;
using System.Text;


public class Product
{
    private const int MIN_COST = 0;

    private string name;
    private decimal cost;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
    
    public decimal Cost
    {
        get { return cost; }
        set
        {
            cost = value;

            if (cost < MIN_COST)
                throw new ArgumentException("Money cannot be negative");
        }
    }

    public Product()
    {}

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

}

