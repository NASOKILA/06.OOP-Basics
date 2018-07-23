using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre : Tyre
{
    public  UltrasoftTyre(double hardness, double grip) 
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    private double grip;
    private double degradation;

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }
   
    public override double Degradation
    {
        get
        {
            return this.degradation;
        }
        protected set
        {
            if (value < 30)
                throw new ArgumentException("Blown Tyre");

            degradation = value;
        }
    }

    public override void CompleteLap()
    {
        this.Degradation -= (this.Hardness + this.Grip);

        if (this.Degradation < 30)
            throw new ArgumentException("Blown Tyre");
    }
}