using System;
using System.Collections.Generic;
using System.Text;


public abstract class Tyre
{
    //KOGATO IMAME ABSTRAKTEN KLAS SLAGAI PROTEKTED KONSTRUKTOR
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
        //Every tyre starts with 100 points degradation and drops down towards 0
    }

    private string name;
    private double hardness;

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }
    
    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    private double degradation;

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            //If a tyre’s degradation drops below 0 points the tyre blows 
            //If a tyre blows up you should throw an exeption

            if (value < 0)
                throw new ArgumentException("Blown Tyre");

            degradation = value;
        }
    }


    //Upon each lap it’s degradation is reduced by the value of the hardness
    public virtual void CompleteLap()
    {
        this.Degradation = (this.Degradation - this.Hardness); 
    }

}

