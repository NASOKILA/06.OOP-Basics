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

        //ako zapochva s chislo znachi e birthday inache e ime 
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
            
            //ako imame vruzka znachi imame tirence
            if (tokens.Length > 1)
            {

                string firstPerson = tokens[0];
                string secondPerson = tokens[1];
                
                Person currentPerson;

                //ako nqma nikoi s takova ime 
                if (IsBirthday(firstPerson))
                {
                    currentPerson = familyThree
                        .FirstOrDefault(p => p.Birthday == firstPerson);


                    //proverqvame dali imame takuv chovek vuv family three

                    //ako nqmame suzdavame nov
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

                //vzimame tozi chovek koito tursim
                var person = familyThree.FirstOrDefault(e => e.Name == name || e.Birthday == birthday);

                //i mu setvame ime i rojden den
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

                //vzimame indexa na tozi person ot copy kolekciqta
                Person copyPerson = copy.FirstOrDefault(e => e.Name == name || e.Birthday == birthday);



                //ako e null go triem
                if (copyPerson != null)
                {
                    //go triem ot purvonachalniq spisuk kato suberem dvata indexa
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
        //proverqvame za deca 

        var childPerson = new Person();

        //ako e rojden den
        if (IsBirthday(child))
        {
            if (!familyThree.Any(p => p.Birthday == child))
            {
                childPerson.Birthday = child;
            }
            else
            {
                //inache go vzimame ot kolekciqta
                childPerson = familyThree.First(r => r.Birthday == child);
            }
            
        }
        else
        {

            //inache proverqvame za imeto
            if (!familyThree.Any(p => p.Name == child))
            {
                childPerson.Name = child;
            }
            else
            {
                //inache go vzimame ot kolekciqta
                childPerson = familyThree.First(r => r.Name == child);
            }
        }

        //dobavqme kum parents kato dete i kum deca kato parent
        parentPerson.Children.Add(childPerson);
        childPerson.Parents.Add(childPerson);

        //i nakraq dobavqme kum family three
        familyThree.Add(parentPerson);  
        
    }

    static bool IsBirthday(string input) {

        return Char.IsDigit(input[0]);
    }

}

