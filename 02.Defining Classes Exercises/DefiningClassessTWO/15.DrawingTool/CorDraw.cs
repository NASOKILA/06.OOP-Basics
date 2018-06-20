using System;
using System.Collections.Generic;
using System.Text;


public class CorDraw
{

    public Rectangle rectangle;
    public Square square;

    public CorDraw(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    public CorDraw(Square square)
    {
        this.square = square;
    }
}

