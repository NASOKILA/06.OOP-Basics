using _05.Date_Modifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        string startDate = Console.ReadLine();

        string endDate = Console.ReadLine();

        DateModifier dateModifier = new DateModifier();

        dateModifier.CalculateDays(startDate, endDate);
        var result = dateModifier.diffOfDays;

        Console.WriteLine(result);
    }
}

