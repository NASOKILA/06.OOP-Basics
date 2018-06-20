using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Smarthphone : ICalling, IBrowsing
{
    private string number;

    private string website;

    public string Number
    {
        get { return number; }
        set { number = value; }
    }
    
    public string Website
    {
        get { return website; }
        set { website = value; }
    }


    public Smarthphone()
    {}
    

    public string Brawsing()
    {

        string result = this.Website.Any(e => Char.IsDigit(e))
            ? $"Invalid URL!"
            : $"Browsing: {this.Website}!";

        return result;
    }
        
    public string Calling()
    {

        string result = this.Number.All(e => Char.IsDigit(e))
            ? $"Calling... {this.Number}"
            : $"Invalid URL!";

        return result;
    }
    
}

