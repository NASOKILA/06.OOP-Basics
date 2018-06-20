using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Id { get; set; }

    public string Birthdate { get; set; }

    public Citizen()
    {}

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

}

