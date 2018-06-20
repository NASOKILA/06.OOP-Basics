using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private const int MIN_MONEY = 0;

    private string name;
    private decimal money;

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

    public decimal Money
    {
        get { return money; }
        set
        {
            money = value;

            if (money < MIN_MONEY)
                throw new ArgumentException("Money cannot be negative");
        }
    }


    private List<Product> products;

    public List<Product> Products
    {
        get { return products; }
        set { products = value; }
    }

    public Person()
    {
        this.Products = new List<Product>();
    }

    public Person(string name, decimal money)
          :this()
    {
        this.Name = name;
        this.Money = money;
    }


}

