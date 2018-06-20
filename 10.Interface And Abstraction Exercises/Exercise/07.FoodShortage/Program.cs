using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> citizenOrRabel = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (input.Count == 4)
                {
                    //Citizen
                    citizenOrRabel.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                    
                }
                else if (input.Count == 3)
                {
                    //Rabel

                    //Ako imame veche s takova ime go propuskame
                    if(!citizenOrRabel.Any(p => p.Name == input[0]))
                        citizenOrRabel.Add(new Rabel(input[0], int.Parse(input[1]), input[2]));
                }

            }

            string name;
            while ((name = Console.ReadLine()) != "End")
            {

                //purvo gledame dali se sudurja 
                if (citizenOrRabel.Any(p => p.Name == name)) {

                    IBuyer currentPerson = citizenOrRabel.First(p => p.Name == name);
                    currentPerson.BuyFood();

                }

            }

            int sumOfAllFood = citizenOrRabel.Select(p => p.Food).Sum();
            Console.WriteLine(sumOfAllFood);

        }
    }
}
