using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Family
{
    List<Person> people;

    public Family()
    {
        people = new List<Person>();
    }
    
    public void AddMember(Person member)
    {
        if(!people.Contains(member))
            people.Add(member);

    }

    public List<Person> GetOverPeopleThirty() {

        return people.Where(m => m.Age > 30).OrderBy(s => s.Name).ToList();
    }

}

