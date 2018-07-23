using System;
using System.Linq;

namespace _05.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split().ToArray()[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] dougnInput = Console.ReadLine().Split().ToArray();

                string flourType = dougnInput[1];
                string bakingTechnique = dougnInput[2];
                decimal doughWeight = decimal.Parse(dougnInput[3]);

                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);

                pizza.SetDough(dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = command.Split();
                    string toppingType = toppingInput[1];
                    decimal toppingWeight = decimal.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopic(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
