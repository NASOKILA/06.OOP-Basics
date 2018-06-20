using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    public List<Person> people { get; set; }
     = new List<Person>();

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public void GetOldestMember()
    {
        Person oldestMember = people
            .OrderByDescending(m => m.age)
            .First();

        Console.WriteLine($"{oldestMember.name} {oldestMember.age}");
    }

}

