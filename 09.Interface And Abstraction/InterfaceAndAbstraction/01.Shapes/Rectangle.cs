using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle : IDrawable
{

    private int width;

    private int height;

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }



    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void Draw()
    {
        Console.WriteLine(new string('*', this.Width));

        for (int i = 0; i < this.Height - 2; i++)
        {
            Console.Write('*');
            Console.Write(new string(' ', this.Width - 2));
            Console.WriteLine('*');
        }

        Console.WriteLine(new string('*', this.Width));
    }

}

