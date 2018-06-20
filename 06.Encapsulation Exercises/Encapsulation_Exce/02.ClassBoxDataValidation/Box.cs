using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private decimal length;
    private decimal height;
    private decimal width;

    public Box()
    { }

    public Box(decimal length, decimal width, decimal height)
    {
        
            this.length = length;
            if (length <= 0)
                throw new ArgumentException("Length cannot be zero or negative. ");

            this.width = width;
            if (width <= 0)
                throw new ArgumentException("Width cannot be zero or negative. ");

            this.height = height;
            if (height <= 0)
                throw new ArgumentException("Height cannot be zero or negative. ");
        
    }


    public string SurfaceArea()
    {
        decimal surfaceArea = ((2 * this.length) * this.width) + ((2 * this.length) * this.height) + ((2 * this.width) * this.height);
        return $"Surface Area - {surfaceArea:f2}";
    }

    public string LateralSurfaceArea()
    {
        decimal lateralSurfaceArea = (2 * length * height) + (2 * width * height);
        return $"Lateral Surface Area - {lateralSurfaceArea:f2}";
    }

    public string Volume()
    {
        decimal volume = length * width * height;
        return $"Volume - {volume:f2}";
    }

}