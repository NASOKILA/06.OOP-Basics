using System;
using System.Collections.Generic;
using System.Text;


public abstract class Tyre
{
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
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
            if (value < 0)
                throw new ArgumentException("Blown Tyre");

            degradation = value;
        }
    }

    public virtual void CompleteLap()
    {
        this.Degradation = (this.Degradation - this.Hardness); 
    }
}