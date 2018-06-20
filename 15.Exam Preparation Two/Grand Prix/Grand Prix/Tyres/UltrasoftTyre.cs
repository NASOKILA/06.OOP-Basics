using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre : Tyre
{
    public  UltrasoftTyre(double hardness, double grip) 
        : base("Ultrasoft", hardness)
    {
        //The name of this tyre is always “Ultrasoft
        this.Grip = grip;
    }

    //has an additional property
    private double grip;
    private double degradation;

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    // prezapisvame si degradation propertito    
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
        //Upon each lap, it’s Degradation drops down by its Hardness summed with its Grip
        this.Degradation -= (this.Hardness + this.Grip);

        //If a tyre’s degradation drops below 0 points the tyre blows 
        //If a tyre blows up you should throw an exeption
        if (this.Degradation < 30)
            throw new ArgumentException("Blown Tyre");
    }
}

