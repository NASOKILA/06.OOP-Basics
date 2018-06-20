using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

            //ZA DA POLZVAME GetName() METODA I OT DVATA INTERFEISA TRQBVA DA KASTNEM OBEKTA citisen !!!
            IPerson p = (IPerson)citizen;
            Console.WriteLine(p.GetName());

            IResident r = (IResident)citizen;
            Console.WriteLine(r.GetName());

        }


    }
}

