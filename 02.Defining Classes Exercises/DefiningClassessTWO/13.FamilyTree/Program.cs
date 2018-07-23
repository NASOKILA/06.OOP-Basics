using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var familyThree = new List<Person>();

        string personInput = Console.ReadLine();

        Person mainPerson = new Person();

        if (IsBirthday(personInput))
        {
            mainPerson.Birthday = personInput;
        }
        else
        {
            mainPerson.Name = personInput;
        }
        
        string command;
        
        while ((command = Console.ReadLine()) != "End")
        {

            string[] tokens = command
                .Split(new string[]{" - "},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            if (tokens.Length > 1)
            {

                string firstPerson = tokens[0];
                string secondPerson = tokens[1];
                
                Person currentPerson;
 
                if (IsBirthday(firstPerson))
                {
                    currentPerson = familyThree
                        .FirstOrDefault(p => p.Birthday == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = new Person();
                        currentPerson.Birthday = firstPerson;
                        familyThree.Add(currentPerson);
                    }

                    SetChild(familyThree, currentPerson, secondPerson);
                }
                else
                {
                    currentPerson = familyThree
                        .FirstOrDefault(p => p.Name == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = new Person();
                        currentPerson.Name = firstPerson;
                        familyThree.Add(currentPerson); 
                    }

                    SetChild(familyThree, currentPerson, secondPerson);
                }
            }
            else
            {
                tokens = tokens[0].Split();

                string name = $"{tokens[0]} {tokens[1]}";

                string birthday = tokens[2];

                var person = familyThree.FirstOrDefault(e => e.Name == name || e.Birthday == birthday);

                if (person == null)
                {
                    person = new Person();
                    person.Name = name;
                    person.Birthday = birthday;

                }

                person.Name = name;
                person.Birthday = birthday;

                int index = familyThree.IndexOf(person) + 1;

                int count = familyThree.Count - index;

                Person[] copy = new Person[count];

                familyThree.CopyTo(index, copy, 0, count);

                Person copyPerson = copy.FirstOrDefault(e => e.Name == name || e.Birthday == birthday);

                if (copyPerson != null)
                {
                    familyThree.Remove(copyPerson);
                    person.Parents.AddRange(copyPerson.Parents);
                    person.Parents = person.Parents.Distinct().ToList();

                    person.Children.AddRange(copyPerson.Children);
                    person.Children = person.Children.Distinct().ToList();
                }
            }
        }

        Console.WriteLine(mainPerson);

        Console.WriteLine("Parents:");
        foreach (var p in mainPerson.Parents)
            Console.WriteLine(p);
       
        Console.WriteLine("Children:");
        foreach (var c in mainPerson.Children)
            Console.WriteLine(c);   
    }

    private static void SetChild(List<Person> familyThree, Person parentPerson, string child)
    { 
        var childPerson = new Person();

        if (IsBirthday(child))
        {
            if (!familyThree.Any(p => p.Birthday == child))
            {
                childPerson.Birthday = child;
            }
            else
            {
                childPerson = familyThree.First(r => r.Birthday == child);
            }
        }
        else
        {

            if (!familyThree.Any(p => p.Name == child))
            {
                childPerson.Name = child;
            }
            else
            {
                childPerson = familyThree.First(r => r.Name == child);
            }
        }

        parentPerson.Children.Add(childPerson);
        childPerson.Parents.Add(childPerson);

        familyThree.Add(parentPerson);        
    }

    static bool IsBirthday(string input) {

        return Char.IsDigit(input[0]);
    }
}