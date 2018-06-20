using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {


        List<ISoldier> soldiers = new List<ISoldier>();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            decimal salary = decimal.Parse(tokens[4]);

            //Pravim si promenliva v koqto da si vkarvame voinicite
            //Znaem che ISoldier e nasleden iterfeis ot vsichki voinici
            ISoldier soldier = null;
            try
            {

                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;


                    case "LeutenantGeneral":

                        //Pravim si leitananta:
                        var lieutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                        //Dobavqme mu 
                        for (int i = 5; i < tokens.Count; i++)
                        {
                            //vzimame si private i go dobavqme v spisuka s privates na leitananta
                            int privateId = int.Parse(tokens[i]);
                            ISoldier @private = soldiers.First(p => p.Id == privateId);
                            lieutenant.AddPrivate(@private);
                        }

                        soldier = lieutenant;
                        break;

                    case "Commando":
                        string commandoCorps = tokens[5];
                        var commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                        for (int i = 6; i < tokens.Count; i++)
                        {
                            string codeName = tokens[i];
                            string missionState = tokens[++i];
                            try
                            {
                                IMission mission = new Mission(codeName, missionState);
                                commando.AddMission(mission);
                            }
                            catch { }
                        }

                        soldier = commando;
                        break;

                    case "Engineer":

                        string engineerCorps = tokens[5];

                        //Pravim si leitananta:
                        var engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

                        //Dobavqme mu 
                        for (int i = 6; i < tokens.Count; i++)
                        {
                            //Dobavqme mu Repairs na Enjinera
                            string partName = tokens[i];
                            int hoursWorked = int.Parse(tokens[++i]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddRepair(repair);

                        }

                        soldier = engineer;
                        break;

                    case "Spy":
                        int codeNumber = (int)salary;
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;

                    default:
                        throw new ArgumentException("Invalid soldier type !");

                }

                soldiers.Add(soldier);

            }
            catch //(Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            
        }


        foreach (var s in soldiers)
        {
            Console.WriteLine(s);
        }

    }
}

