using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        string input = Console.ReadLine();

        PriceCalcultor priceCalcultor = new PriceCalcultor(input);

        string totalPrice = priceCalcultor.CalculateTotalPrice();
        Console.WriteLine(totalPrice);
    }
}

