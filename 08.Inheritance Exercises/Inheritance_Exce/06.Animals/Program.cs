using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        string command;
        while ((command = Console.ReadLine()) != "Beast!")
        {
            try {

                string[] input = command.Split().ToArray();

                string[] secondLine =
                    Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = secondLine[0];
                int age = int.Parse(secondLine[1]);
                string gender = secondLine[2];

                if (input.Length == 1)
                {
                    string classToMake = input[0];

                    if (classToMake == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(classToMake);
                        Console.WriteLine(dog);
                        Console.WriteLine(dog.ProduceSound());
                    }
                    else if (classToMake == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(classToMake);
                        Console.WriteLine(frog);
                        Console.WriteLine(frog.ProduceSound());
                    }
                    else if (classToMake == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(classToMake);
                        Console.WriteLine(cat);
                        Console.WriteLine(cat.ProduceSound());
                    }
                    else if (classToMake == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(classToMake);
                        Console.WriteLine(kitten);
                        Console.WriteLine(kitten.ProduceSound());
                    }
                    else if (classToMake == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(classToMake);
                        Console.WriteLine(tomcat);
                        Console.WriteLine(tomcat.ProduceSound());
                    }
                    else
                        throw new ArgumentException("Invalid input!");


                }

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
           
            
        }
    }
}

