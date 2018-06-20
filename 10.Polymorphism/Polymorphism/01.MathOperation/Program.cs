using System;


class Program
{
    static void Main(string[] args)
    {
        //Tova e function overloading: da imame mnogo metodi s edno i sushto ime
        //koito pravat razlichni neshta, v zavisimost kakvi parametri im podadem.
        MathOperations mo = new MathOperations();
        Console.WriteLine(mo.Add(2, 3));
        Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
        Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));
    }
}

