using System;
using System.Collections.Generic;
using System.Text;


public class Rabel: IBuyer
{
    public string  Name { get; set; }

    public int Age { get; set; }

    public string Group { get; set; }

    public int Food { get; private set; }

    public string Id { get; set; }

    public string Birthdate { get; set; }

    public Rabel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;

        this.Food = 0;
        this.Id = string.Empty;
        this.Birthdate = string.Empty;
    }

    public int BuyFood()
    {
        return this.Food += 5;
    }
}

