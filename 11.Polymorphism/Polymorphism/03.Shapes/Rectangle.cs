using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle : Shape
{
    private const int MIN_WIDTH = 0;
    private const int MIN_HEIGHT = 0;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }
    
    private double height;

    private double width;

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(this.Height), $"cannot be less than or equal to {MIN_HEIGHT}");
            height = value;
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(this.Width), $"cannot be less than or equal to {MIN_WIDTH}");
            width = value;
        }
    }
    
    public override double CalculateArea()
    {
        double result = this.Width * this.Height;
        return result;    
    }

    public override double CalculatePerimeter()
    {
        double result = 2 * (this.Width + this.Height);
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
    
}

