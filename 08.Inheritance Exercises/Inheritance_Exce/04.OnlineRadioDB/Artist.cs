using System;
using System.Collections.Generic;
using System.Text;

public class Artist
{
    private string name;

    public Artist()
    { }

    public Artist(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");

            name = value;
        }
    }

}

