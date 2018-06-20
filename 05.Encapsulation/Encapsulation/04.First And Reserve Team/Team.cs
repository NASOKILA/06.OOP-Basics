using System;
using System.Collections.Generic;
using System.Text;


public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;


    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    //ReadOnly
    public List<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    //ReadOnly
    public List<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }
    
    public Team()
    {}

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public void AddPlayer (Person person) {

        if (person.Age < 40)
            this.firstTeam.Add(person);
        else
            this.reserveTeam.Add(person);
    }


    public void Print()
    {
        Console.WriteLine($"First team has {FirstTeam.Count} players.");
        Console.WriteLine($"Last team has {ReserveTeam.Count} players.");
    }
    

}

