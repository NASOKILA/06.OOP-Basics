using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Trainer
{
    public Trainer()
    {
        NumberOfBadges = 0;
        Pokemons = new List<Pokemon>();
    }

    public Trainer(string name)
        :this()
    {
        Name = name;
    }

    public string Name { get; set; }

    public int NumberOfBadges { get; set; }

    public List<Pokemon> Pokemons { get; set; }
            
}

