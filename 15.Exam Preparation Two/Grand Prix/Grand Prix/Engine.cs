using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
        Run();
    }

    public RaceTower raceTower { get; set; }

    public void Run()
    {

        //You should stop reading the input when drivers complete all laps.
        while (true)
        {

            List<string> commandArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> methodArgs = commandArgs.Skip(1).ToList();

            string command = commandArgs[0];

            if (command == "RegisterDriver")
            {
                raceTower.RegisterDriver(methodArgs);
            }
            else if (command == "Leaderboard")
            {
                Console.WriteLine(raceTower.GetLeaderboard());
            }
            else if (command == "CompleteLaps")
            {
                string result = raceTower.CompleteLaps(methodArgs);

                //Ako nqmame izprevarvaniq i nqmame greshka
                if (string.IsNullOrWhiteSpace(result))
                    Console.WriteLine(result);
                
            }
            else if (command == "Box")
            {
                raceTower.DriverBoxes(methodArgs);
            }
            else if (command == "ChangeWeather")
            {
                raceTower.ChangeWeather(methodArgs);
            }
            
            if (this.raceTower.IsRaceOver)
                break;
        }
    }
}

