using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine()
                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

        string carName = carInfo[0];
        double carFuelQuantity = double.Parse(carInfo[1]);
        double carLitersPerKm = double.Parse(carInfo[2]);


        string[] truckInfo = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string truckName = truckInfo[0];
        double truckFuelQuantity = double.Parse(truckInfo[1]);
        double truckLitersPerKm = double.Parse(truckInfo[2]);


        Car car = new Car(carFuelQuantity, carLitersPerKm);

        Truck truck = new Truck(truckFuelQuantity, truckLitersPerKm);


        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commandInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = commandInput[0];
            string vehicle = commandInput[1];

            if (command == "Drive")
            {

                double distanceInKm = double.Parse(commandInput[2]);

                if (vehicle == carName)
                {
                    
                    bool canTravel = car.FuelQuantity >= (distanceInKm * car.FuelConsumptionInLitersPerKm);
                    if (canTravel)
                        car.Driving(distanceInKm);
                    else
                    {
                        Console.WriteLine($"{vehicle} needs refueling");
                        continue;
                    }
                }
                else if (vehicle == truckName)
                {
                    bool truckTravel = truck.FuelQuantity >= (distanceInKm * truck.FuelConsumptionInLitersPerKm);
                    if (truckTravel)
                        truck.Driving(distanceInKm);
                    else
                    {
                        Console.WriteLine($"{vehicle} needs refueling");
                        continue;
                    }
                }


                Console.WriteLine($"{vehicle} travelled {distanceInKm} km");


            }
            else if (command == "Refuel")
            {

                double liters = double.Parse(commandInput[2]);

                if (vehicle == carName)
                {
                    car.Refueling(liters);
                }
                else if (vehicle == truckName)
                {
                    truck.Refueling(liters);
                }

            }

        }


        Console.WriteLine($"Car: {car.FuelQuantity:f2}");

        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");



    }

}

