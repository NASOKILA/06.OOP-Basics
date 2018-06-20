using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Player
{
    private string name;
    private List<Stat> stats;

    private double skillLevel { get; set; }


    public List<Stat> Stats
    {
        get { return stats; }
        set { stats = value; }
    }

    public string Name
    {
        get { return name; }
        set
        {
            
            if (value == null || value == string.Empty || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }

    public Player()
    {
        this.Stats = new List<Stat>();
    }

    public Player(string name, List<Stat> stats)
    {
        this.Name = name;
        this.Stats = stats;

        getSkillLevel();
    }



    private void getSkillLevel(){

         skillLevel = stats
            .Select(s => s.ValueOfStat)
            .Average();
    }
}

