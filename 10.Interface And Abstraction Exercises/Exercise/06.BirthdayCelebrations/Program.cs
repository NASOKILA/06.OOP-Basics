using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {

        List<IEntity> petsRobotsOrCitizens = new List<IEntity>();

        string command;
            while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (tokens[0] == "Robot")
            {
                //robot 
                //Robot robot = new Robot(tokens[1], tokens[2]);
                //petsRobotsOrCitizens.Add(robot);
            }
            else if (tokens[0] == "Citizen")
            {
                //chovek
                Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                petsRobotsOrCitizens.Add(citizen);
            }
            else if (tokens[0] == "Pet")
            {
                //Pet
                Pet pet = new Pet(tokens[1], tokens[2]);
                petsRobotsOrCitizens.Add(pet);
            }

        }

        string fakeYear = Console.ReadLine();
        
        foreach (var item in petsRobotsOrCitizens)
        {
            string year = item.Birthdate.Substring(6);
            if (year == fakeYear)
            {
                Console.WriteLine(item.Birthdate);
            }
        }


        
    }
}



