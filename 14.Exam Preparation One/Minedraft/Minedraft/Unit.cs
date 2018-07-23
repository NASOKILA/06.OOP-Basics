using System;
using System.Collections.Generic;
using System.Text;


public abstract class Unit
{
    protected Unit(string id)
    {
        this.id = id;
    }

    public string id { get; set; }  
}