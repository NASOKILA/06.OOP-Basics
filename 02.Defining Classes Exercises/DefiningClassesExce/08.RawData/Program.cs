
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {

            string[] input = Console.ReadLine().Split(' ').ToArray();

            Model model = new Model(input[0]);

            Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
            
            Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);
            

            List<Tire> tires = new List<Tire>();

            Tire tireOne = new Tire(double.Parse(input[5]), int.Parse(input[6]));
            tires.Add(tireOne);

            Tire tireTwo = new Tire(double.Parse(input[7]), int.Parse(input[8]));
            tires.Add(tireTwo);

            Tire tireThree = new Tire(double.Parse(input[9]), int.Parse(input[10]));
            tires.Add(tireThree);

            Tire tireFour = new Tire(double.Parse(input[11]), int.Parse(input[12]));
            tires.Add(tireFour);

            Car car = new Car(model, engine, cargo, tires);

            cars.Add(car);

        }

        string cargoTypeToSearch = Console.ReadLine();

        if (cargoTypeToSearch == "fragile")
        {
            List<Car> carsToPrint = cars
                .Where(c => c.Cargo.CargoType == cargoTypeToSearch 
                && c.Tires.Any(t => t.TirePressure < 1)).ToList();

            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car.Model.Name);
            }
            
        }
        else if (cargoTypeToSearch == "flamable")
        {

            List<Car> carsToPrint = cars
                .Where(c => c.Cargo.CargoType == cargoTypeToSearch
                && c.Engine.EnginePower > 250).ToList();

            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car.Model.Name);
            }

        }



    }
}

