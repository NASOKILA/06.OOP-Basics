using InterfaceAndAbstraction.Animals;
using InterfaceAndAbstraction.Arms;
using InterfaceAndAbstraction.Cars;
using InterfaceAndAbstraction.Food;
using System;
using System.Collections.Generic;

namespace InterfaceAndAbstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ANIMALS -----------------------------------------");
           
            Animal someAnimal = new Cat();

            someAnimal.Sound(); 
           
            Console.WriteLine();
            
            Animal animalType = new Dog();
            animalType.Sound();   

            Console.WriteLine();
            List<Animal> listOfAnimals = new List<Animal>();

            listOfAnimals.Add(new Cat());
            listOfAnimals.Add(new Dog());
            listOfAnimals.Add(new Frog());

            foreach (var animal in listOfAnimals)
            {
                animal.Sound();
            }

            Console.WriteLine();
            
            Dog dog = new Dog();
            dog.Eat();

            Console.WriteLine();

            Console.WriteLine("CARS --------------------------------------------");
            
            Opel opel = new Opel();
            opel.Start();

            Bmw bmw = new Bmw();
            bmw.Start();

            Fiat fiat = new Fiat();
            fiat.Start();

            Console.WriteLine();
            Car car = new Opel();

            car.Start(); 
			
            Console.WriteLine();

            Console.WriteLine("FOOD -------------------------------------------");
           
            List<IFood> foods = new List<IFood>();

            foods.Add(new Meat("Fish", (decimal)10.99, (decimal)2.55));
            foods.Add(new Chips("Pomber", (decimal)3.99, (decimal)0.80));
            foods.Add(new Meat("Beans", (decimal)6.99, (decimal)1.20));

            foreach (var food in foods)
                food.Information();

            Console.WriteLine();
            Console.WriteLine("ARMS --------------------------------------------");
            
            List<IArms> arms = new List<IArms>();
                arms.Add(new Knive("Knife", 0, 0.60));
                arms.Add(new Pistol("Knife", 0, 0.60));
                arms.Add(new Shoutgun("Knife", 0, 0.60));

            foreach (var arm in arms)
                Console.WriteLine(arm.PrintInfo());

            Console.WriteLine();
            
			List<IPistols> pistols = new List<IPistols>();
                pistols.Add(new Barrera("8mm Barrera", "Germany", "Barrera", 12, 0.80));
                pistols.Add(new Barrera("Deasert Eagle 3.5", "Switserland", "Deasert Eagle", 7, 1.20));
            
            foreach (var pistol in pistols)
                Console.WriteLine(pistol.PrintInfo());

            Console.WriteLine();

            List<IKnives> knives = new List<IKnives>();
                knives.Add(new ButterflyKnive("Peperutka", 0, 0.50, 20, "Black"));
                knives.Add(new AutomaticKnife("Avtomatichen", 0, 0.40, 15, "White"));

            foreach (var knive in knives)
                Console.WriteLine(knive.PrintInfo());
                Console.WriteLine(knive.PrintInfo());
        }
    }
}
