using System;
using System.Collections.Generic;
using System.Text;


public class Citizen: IEntity, IBuyer
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Id { get; set; }

    public string Birthdate { get; set; }

    public int Food { get; private set; }

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;

        this.Food = 0;
    }

    public int BuyFood()
    {
        return this.Food += 10;
    }
}

