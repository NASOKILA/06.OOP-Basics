using System;
using System.Collections.Generic;
using System.Text;


public class Pet : IPets
{
    public string Name { get; set; }

    public string Id { get; set; }

    public string Birthdate { get; set; }

    public Pet()
    {}
    
    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
        this.Id = null;
    }

}

