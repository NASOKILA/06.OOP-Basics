using System;
using System.Collections.Generic;
using System.Text;


public class Circle : Shape
{
    private const int MIN_RADIUS = 0;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    private double radius;

    public double Radius
    {
        get { return radius; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(this.Radius)} cannot be less than or equal to {MIN_RADIUS}");
            radius = value;
        }
    }
    
    public override double CalculateArea()
    {
        double result = Math.PI * Math.Pow(this.Radius, 2);
        return result;
    }

    public override double CalculatePerimeter()
    {
        double result = 2 * Math.PI * this.Radius;
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + this.GetType().Name; 
    }

}

