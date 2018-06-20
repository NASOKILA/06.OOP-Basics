using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rectangle
{
    public Rectangle(string id, int width, int height, List<int> coordinates)
    {
        ID = id;
        Width = width;
        Height = height;
        Coordinates = coordinates;
    }

    public string ID { get; set; }
    

    public int Width { get; set; }

    public int Height { get; set; }

    public List<int> Coordinates { get; set; }

    public bool Intercect(Rectangle rectangle)
    {
        //If they intercect returns true
        if (rectangle.Coordinates.Any() == Coordinates.Any())
            return true;
        

        return false;
    }

}

