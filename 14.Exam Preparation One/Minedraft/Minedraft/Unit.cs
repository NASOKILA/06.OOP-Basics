using System;
using System.Collections.Generic;
using System.Text;


public abstract class Unit
{
    //Na abstraktnite klasove konstrukturite trqbva da sa PROTECTED zashtotonqma smisul da moje da se dostupqt otvun

    protected Unit(string id)
    {
        this.id = id;
    }

    public string id { get; set; }
    
}

