using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    private Point topLeft;
    private Point bottomRight;

    public Point TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }

    
    public Point BottomRight
    {
        get { return bottomRight; }
        set { bottomRight = value; }
    }


    public Rectangle()
    {

    }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.TopLeft = topLeft;
        this.BottomRight = bottomRight;
    }

    public bool Contains(Point point) {

        bool result;
        if (point.X >= this.TopLeft.X && point.X <= BottomRight.X
            && point.Y >= TopLeft.Y && point.Y <= BottomRight.Y)
            result = true;
        else
            result = false;

        return result;
    }

}

