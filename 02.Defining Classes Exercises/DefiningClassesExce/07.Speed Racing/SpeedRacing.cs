using System;
using System.Collections.Generic;
using System.Linq;

public class SpeedRacing
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            // <Model> <FuelAmount> <FuelConsumptionFor1km>

            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' })
                .ToArray();

            string model = input[0];
            decimal fuelAmount = decimal.Parse(input[1]);
            decimal fuelConsumptionFor1km = decimal.Parse(input[2]);

            Car car = new Car()
            {
                model = model,
                fuelAmount = fuelAmount,
                fuelCunsumptionPerKm = fuelConsumptionFor1km
            };

            if(!cars.Any(c => c.model == model))
                cars.Add(car);

            
        }

        while (true)
        {
            //Drive <CarModel>  <amountOfKm>
            string[] commandInput = Console.ReadLine()
                .Split(new char[] { ' ' })
                .ToArray();

            if (commandInput[0] == "End")
                break;

            string command = commandInput[0];

            string carModel = commandInput[1];

            decimal amountOfKm = decimal.Parse(commandInput[2]);

            Car car = cars
                .SingleOrDefault(c => c.model == carModel);

            bool canTravel = car.CalculateDistance(amountOfKm);
            if (canTravel)
            {
                car.distanceTraveled = car.distanceTraveled + amountOfKm;
                
                car.fuelAmount = 
                    car.fuelAmount - (car.fuelCunsumptionPerKm * amountOfKm);
                
            }
            else
                Console.WriteLine("Insufficient fuel for the drive");

        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.model} {c.fuelAmount:f2} {c.distanceTraveled}");
        }
        
    }
}

