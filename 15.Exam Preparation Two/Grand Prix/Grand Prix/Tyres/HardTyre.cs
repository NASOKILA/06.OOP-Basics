using System;
using System.Collections.Generic;
using System.Text;


public class HardTyre : Tyre
{
    public HardTyre(double hardness) 
        : base("Hard", hardness)
    {
        //Hard tyres have less grip and slow down the car but endure bigger distance
        //this.Grip = grip;
    }
/*
    private double grip;

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }
*/

}

