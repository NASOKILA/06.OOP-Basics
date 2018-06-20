using System.Collections.Generic;

public class Person
{
    public Person()
    {}

    public string Name { get; set; }

    public Company Company { get; set; }

    public Car Car { get; set; }

    public List<Pokemon> Pokemons { get; set; }
        = new List<Pokemon>();

    public List<Children> Children { get; set; }
        = new List<Children>();
    
    public List<Parent> Parents { get; set; }
        = new List<Parent>();
    
}

