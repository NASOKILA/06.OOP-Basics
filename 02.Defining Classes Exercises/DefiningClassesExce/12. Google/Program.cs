using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {

        List<Person> existingPeople = new List<Person>();

        while (true)
        {

            string[] input = Console.ReadLine().Split(new char[] { ' ' })
                .ToArray();

            if (input[0] == "End")
                break;


            string name = input[0];


            Person person = new Person();
            if (existingPeople.Any(p => p.Name == name))
            {
                //Ako sushtestvuva
                person = existingPeople
                    .SingleOrDefault(p => p.Name == name);


            }
            person.Name = name;

            if (input[1] == "company")
            {
                
                Company company = new Company();
                company.CompanyName = input[2];
                company.Department = input[3];
                company.Salary = decimal.Parse(input[4]);

                person.Company = company;

            }
            else if (input[1] == "car")
            {
                string carModel = input[2];

                string carSpeed = input[3];

                Car car = new Car();
                car.CarModel = input[2];
                car.CarSpeed = int.Parse(input[3]);

                person.Car = car;

            }
            else if (input[1] == "pokemon")
            {
                Pokemon pokemon = new Pokemon()
                {
                    pokemonName = input[2],
                    pokemonType = input[3]
                };

                //Ako ne sushtetvuva takuv pokemon v negovite pokemoni mu go dobavqme
                if(!person.Pokemons.Any(p => p.pokemonName == input[2] && p.pokemonType == input[3]))
                    person.Pokemons.Add(pokemon);


            }
            else if (input[1] == "parents")
            {

                DateTime birthDay = DateTime
                    .Parse(input[3]);

                Parent parent = new Parent()
                {
                    ParentName = input[2],
                    parentBirthday = birthDay
                };

                //Ako ne go sudurja tozi parent mu go dabavqme
                if(!person.Parents.Any(p => p.ParentName == input[2] && p.parentBirthday == birthDay))
                    person.Parents.Add(parent);

            }
            else if (input[1] == "children")
            {

                DateTime birthDay = DateTime
                    .Parse(input[3]);
                    
                Children child = new Children()
                {
                   ChildName = input[2],
                   ChildBirthday = birthDay   
                };

                //Ako ne go sudurja tozi parent mu go dabavqme
                if (!person.Children.Any(c => c.ChildName == input[2] && c.ChildBirthday == birthDay))
                    person.Children.Add(child);
                
            }

            if(!existingPeople.Any(p => p.Name == name))
            existingPeople.Add(person);
        }


        string persoToPrintStr = Console.ReadLine();

        Person personToPrint = existingPeople
            .SingleOrDefault(p => p.Name == persoToPrintStr);

        Console.WriteLine(personToPrint.Name);

        Console.WriteLine($"Company:");
        if(personToPrint.Company != null)
            Console.WriteLine($"{personToPrint.Company.CompanyName} {personToPrint.Company.Department} {personToPrint.Company.Salary:f2}");

        Console.WriteLine($"Car:");
        if (personToPrint.Car != null)
            Console.WriteLine($"{personToPrint.Car.CarModel} {personToPrint.Car.CarSpeed}");

        Console.WriteLine($"Pokemon:");
        if (personToPrint.Pokemons != null)
            foreach (var p in personToPrint.Pokemons)
                Console.WriteLine($"{p.pokemonName} {p.pokemonType}");
        
        Console.WriteLine("Parents:");
        if (personToPrint.Parents != null)
            foreach (var p in personToPrint.Parents)
                Console.WriteLine($"{p.ParentName} {p.parentBirthday.ToString("dd/MM/yyyy")}");
        
        Console.WriteLine("Children:");
        if (personToPrint.Children != null)
            foreach (var c in personToPrint.Children)
                Console.WriteLine($"{c.ChildName} {c.ChildBirthday.ToString("dd/MM/yyyy")}");
        
    }
}

