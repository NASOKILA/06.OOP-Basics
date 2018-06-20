using System;
using System.Collections.Generic;
using System.Text;


public class Stat
{
    private const int MIN_STAT_VALUE = 0;
    private const int MAX_STAT_VALUE = 100;

    private string name;
    private int valueOfStat;

    public int ValueOfStat
    {
        get { return valueOfStat; }
        set
        {
            if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
            {
                throw new ArgumentException(($"{this.Name} should be between 0 and 100."));
            }

            valueOfStat = value;
        }
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Stat()
    {}

    public Stat(string name, int valueOfStat)
    {
        this.Name = name;
        this.ValueOfStat = valueOfStat;
    }
}

