using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IEntity> robotsOrCitizens = new List<IEntity>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (tokens.Count == 2)
                {
                    //robot 
                    Robot robot = new Robot(tokens[0], tokens[1]);
                    robotsOrCitizens.Add(robot);

                }
                else if (tokens.Count == 3)
                {
                    //chovek
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    robotsOrCitizens.Add(citizen);
                }
                
            }

            string fakeId = Console.ReadLine();

            foreach (var item in robotsOrCitizens)
            {
                if(item.Id.EndsWith(fakeId))
                    Console.WriteLine(item.Id);
            }
            
        }
    }
}
