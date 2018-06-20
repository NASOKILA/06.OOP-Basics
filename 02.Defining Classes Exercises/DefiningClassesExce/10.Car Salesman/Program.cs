using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        List<Engine> engines = new List<Engine>();
        
        List<Car> cars = new List<Car>();

        int linesOfEngines = int.Parse(Console.ReadLine());
        for (int i = 0; i < linesOfEngines; i++)
        {
            string[] engineInput = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Engine engine = new Engine();

            engine.EngineModel = engineInput[0];
            engine.EnginePower = int.Parse(engineInput[1]);
            engine.EngineDisplacement = "n/a";
            engine.EngineEfficiency = "n/a";

            if (engineInput.Length == 3)
            {
                if (engineInput[2].Length == 1)
                {
                    //znachi e efficiency
                    engine.EngineEfficiency = engineInput[2];
                }
                else
                {
                    //znachi e diplacement
                    engine.EngineDisplacement = engineInput[2];
                }
                
            }
            else if (engineInput.Length == 4)
            {
                engine.EngineDisplacement = engineInput[2];
                engine.EngineEfficiency = engineInput[3];
            }


            engines.Add(engine);
        }

        int numOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfCars; i++)
        {

            string[] carInput = Console.ReadLine()
                .Split(' ')
                .ToArray();

            carInput = carInput.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            Car car = new Car();
            car.Model = carInput[0];
            car.Engine = engines.SingleOrDefault(e => e.EngineModel == carInput[1]);
            car.Weight = "n/a";
            car.Color = "n/a";

            if (carInput.Length == 3)
            {
                if (carInput[2].Any(e => Char.IsDigit(e)))
                {
                    //ako sudurja chislo znachi e weight
                    car.Weight = carInput[2];
                }
                else
                {
                    //ako ne znachi e color
                    car.Color = carInput[2];
                }
            }
            else if (carInput.Length == 4)
            {

                //ako duljinata si e 4 si gi setvame i dvete

                if (carInput[2].Any(e => Char.IsDigit(e)))
                {
                    car.Weight = carInput[2];
                    car.Color = carInput[3];
                }
                else
                {
                    car.Weight = carInput[3];
                    car.Color = carInput[2];
                }


            }

            cars.Add(car);
        }

        foreach (var c in cars)
        {
            var result = c.ToString();
            Console.WriteLine(result);
        }
        

    }
}









