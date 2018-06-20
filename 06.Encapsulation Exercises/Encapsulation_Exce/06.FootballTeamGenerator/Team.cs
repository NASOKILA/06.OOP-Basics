using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Team
{
    private string name;
    private List<Player> players;

    public int rating { get; set; }

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

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }
    
    public Team()
    {
        this.Players = new List<Player>();
    }

    public Team(string name)
    {
        this.Name = name;
        this.Players = new List<Player>();
    }


    public int GetRating() {

        double ratingNotParsed = Math.Round(this.Players.Select(p => p.Stats.Select(s => s.ValueOfStat).Average()).Average());
        this.rating = int.Parse(ratingNotParsed.ToString());
        return rating;
    }


    public void AddPlayer(Player player) {
        if(!Players.Contains(player))
            Players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        if (Players.Contains(player))
            Players.Remove(player);
    }

}










