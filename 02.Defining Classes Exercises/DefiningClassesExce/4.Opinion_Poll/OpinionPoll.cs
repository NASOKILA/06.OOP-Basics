
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OpinionPoll
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string name = input[0];

            int age = int.Parse(input[1]);

            Person person = new Person()
            {
                Name = name,
                Age = age
            };

            people.Add(person);
        }

        foreach (var p in people.OrderBy(a => a.Name))
        {
            if (p.Age > 30)
                Console.WriteLine($"{p.Name} - {p.Age}");
        }



    }
}

