using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        

        List<string> commands = new List<string>();
        List<string> results = new List<string>();

        string comm;
        while ((comm = Console.ReadLine()) != "End")
        {
            commands.Add(comm);
        }

        for (int i = 1; i < commands.Count; i += 2)
        {
            
            var animalTokens = commands[i-1]
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            

            string animalType = animalTokens[0];
            string animalName = animalTokens[1];
            double animalWeight = double.Parse(animalTokens[2]);

            if (animalType == "Owl")
            {
                //Bird
                int foodEaten = 0;
                double wingSize = double.Parse(animalTokens[3]);

                Owl owl = new Owl(animalName, animalWeight, foodEaten, wingSize);

                //FOODS
                WorkWithFood(commands, i, owl, owl.EatingIncrement, owl.EadableFoods, results);
            }
            else if (animalType == "Hen")
            {
                //Bird 
                int foodEaten = 0;
                double wingSize = double.Parse(animalTokens[2]);

                Hen hen = new Hen(animalName, animalWeight, foodEaten, wingSize);
                
                //FOODS
                WorkWithFood(commands, i, hen, hen.EatingIncrement, hen.EadableFoods, results);

            }
            else if (animalType == "Mouse")
            {
                int foodEaten = 0;
                string livingRegion = animalTokens[3];
                Mouse mouse = new Mouse(animalName, animalWeight, foodEaten, livingRegion);
                WorkWithFood(commands, i, mouse, mouse.EatingIncrement, mouse.EadableFoods, results);

            }
            else if (animalType == "Dog")
            {
                int foodEaten = 0;
                string livingRegion = animalTokens[3];
                Dog dog = new Dog(animalName, animalWeight, foodEaten, livingRegion);
                WorkWithFood(commands, i, dog, dog.EatingIncrement, dog.EadableFoods, results);

            }
            else if (animalType == "Cat")
            {
                //Felines
                string catLivingRegion = animalTokens[3];
                int foodEaten = 0;
                string catBreed = animalTokens[4];

                Cat cat = new Cat(animalName, animalWeight, foodEaten, catLivingRegion, catBreed);
                
                //FOODS
                WorkWithFood(commands, i, cat, cat.EatingIncrement, cat.EadableFoods, results);
                
            }
            else if (animalType == "Tiger")
            {
                //Felines
                string catLivingRegion = animalTokens[3];
                int foodEaten = 0;
                string catBreed = animalTokens[4];

                Tiger tiger = new Tiger(animalName, animalWeight, foodEaten, catLivingRegion, catBreed);

                //FOODS
                WorkWithFood(commands, i, tiger, tiger.EatingIncrement, tiger.EadableFoods, results);
                
            }


        }

        foreach (var item in results)
            Console.WriteLine(item);

    }

    private static void WorkWithFood(List<string> commands, int i, Animal animal,
        double eatingIncrement, List<string> eadableFoods, List<string> results)
    {
        var fruitTokens = commands[i]
          .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
          .ToArray();
        

        string foodName = fruitTokens[0];
        int foodQuantity = int.Parse(fruitTokens[1]);
        
        if (foodName == "Vegetable")
        {
            Console.WriteLine(animal.AskFood());

            if (eadableFoods.Contains("Vegetable"))
            {
                animal.FoodEaten += foodQuantity;
                animal.Weight += (foodQuantity * eatingIncrement);       
            }
            else
                Console.WriteLine($"{animal.GetType().Name} does not eat Vegetable!");

            results.Add(animal.ToString());

        }
        else if (foodName == "Fruit")
        {
            Console.WriteLine(animal.AskFood());

            if (eadableFoods.Contains("Fruit"))
            {
                animal.FoodEaten += foodQuantity;
                animal.Weight += (foodQuantity * eatingIncrement);
            }
            else
                Console.WriteLine($"{animal.GetType().Name} does not eat Fruit!");
            
            results.Add(animal.ToString());

        }
        else if (foodName == "Meat")
        {
            Console.WriteLine(animal.AskFood());

            if (eadableFoods.Contains("Meat"))
            {
                animal.FoodEaten += foodQuantity;
                animal.Weight += (foodQuantity * eatingIncrement);
            }
            else
                Console.WriteLine($"{animal.GetType().Name} does not eat Meat!");


            results.Add(animal.ToString());
        }
        else if (foodName == "Seeds")
        {
            Console.WriteLine(animal.AskFood());

            if (eadableFoods.Contains("Seeds"))
            {
                animal.FoodEaten += foodQuantity;
                animal.Weight += (foodQuantity * eatingIncrement);
            }
            else
                Console.WriteLine($"{animal.GetType().Name} does not eat Seeds!");


            results.Add(animal.ToString());
        }


    }
}

