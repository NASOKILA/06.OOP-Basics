using System;
using System.Linq;

namespace _02.VehiclesExtention
{
    class Program
    {
        static void Main(string[] args)
        {

            //INPUT
            string[] carInfo = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            string carName = carInfo[0];
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);


            string[] truckInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string truckName = truckInfo[0];
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            string[] busInfo = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            string busName = busInfo[0];
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]); 




            //CREATE THE OBJECTS
            Car car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);
            Bus bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);




            //COMMANDS
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

                        bool carTravel = car.FuelQuantity >= (distanceInKm * car.FuelConsumptionInLitersPerKm);
                        if (carTravel)
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
                    else if (vehicle == busName)
                    {
                        bool busTravel = bus.FuelQuantity >= (distanceInKm * bus.FuelConsumptionInLitersPerKm);
                        if (busTravel)
                            bus.Driving(distanceInKm);
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

                        if ((liters + car.FuelQuantity) > car.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                            continue;
                        }
                        car.Refueling(liters);
                    }
                    else if (vehicle == truckName)
                    {
                        if ((liters + truck.FuelQuantity) > truck.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                            continue;
                        }
                        truck.Refueling(liters);
                    }
                    else if (vehicle == busName)
                    {
                        if ((liters + bus.FuelQuantity) > bus.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                            continue;
                        }

                        bus.Refueling(liters);
                    }

                }
                else if (command == "DriveEmpty")
                {
                    double distanceInKm = double.Parse(commandInput[2]);

                    if (vehicle == busName)
                    {
                        bool busTravel = bus.FuelQuantity >= (distanceInKm * bus.FuelConsumptionInLitersPerKm);
                        if (busTravel)
                        {
                            bus.TurnOffAirConditioner();
                            bus.Driving(distanceInKm);
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                            continue;
                        }
                    }
                }

            }


            //RESULT 
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");

            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
