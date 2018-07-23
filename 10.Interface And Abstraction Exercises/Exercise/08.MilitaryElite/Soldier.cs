using System;
using System.Collections.Generic;
using System.Text;


public abstract class Soldier : ISoldier
{
    public Soldier(int id, string firstName, string lastname)
    {
        this.Id = id;
        this.FirtName = firstName;
        this.LastName = lastname;
    }

    public int Id { get; private set; }

    public string FirtName { get; private set; }

    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"Name: {this.FirtName} {this.LastName} Id: {this.Id}";
    }
}