using System;

class Program
{
    static void Main(string[] args)
    {
        StackOfStrings list = new StackOfStrings();
        list.Push("Nasko");
        list.Push("Asi");
        list.Push("Ivan");
        list.Push("Matiq");

        Console.WriteLine(list.Pop());
        Console.WriteLine(list.Peek());
        Console.WriteLine(list.IsEmpty());
    }
}

