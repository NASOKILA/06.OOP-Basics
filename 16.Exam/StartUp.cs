using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{

            DungeonMaster dungeonMaster = new DungeonMaster();

            while (true)
            {

                string inputCommand = Console.ReadLine();
                if (string.IsNullOrEmpty(inputCommand))
                {
                    break;
                }

                if (dungeonMaster.IsGameOver())
                    break;

                var input = inputCommand
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

                string command = input[0];

                string[] inputToPass = input.Skip(1).ToArray();


                try
                {
                    if (command == "JoinParty")
                    {
                        Console.WriteLine(dungeonMaster.JoinParty(inputToPass));
                    }
                    else if (command == "AddItemToPool")
                    {
                        Console.WriteLine(dungeonMaster.AddItemToPool(inputToPass));
                    }
                    else if (command == "PickUpItem")
                    {
                        Console.WriteLine(dungeonMaster.PickUpItem(inputToPass));
                    }
                    else if (command == "UseItem")
                    {
                        Console.WriteLine(dungeonMaster.UseItem(inputToPass));
                    }
                    else if (command == "UseItemOn")
                    {
                        Console.WriteLine(dungeonMaster.UseItemOn(inputToPass));
                    }


                    else if (command == "GiveCharacterItem")
                    {
                        Console.WriteLine(dungeonMaster.GiveCharacterItem(inputToPass));
                    }
                    else if (command == "GetStats")
                    {
                        Console.WriteLine(dungeonMaster.GetStats());
                    }
                    else if (command == "Attack")
                    {
                        Console.WriteLine(dungeonMaster.Attack(inputToPass));
                    }

                    else if (command == "Heal")
                    {
                        Console.WriteLine(dungeonMaster.Heal(inputToPass));
                    }
                    else if (command == "EndTurn")
                    {
                        Console.WriteLine(dungeonMaster.EndTurn(inputToPass));
                    }
                    else if (command == "GameOver")
                    {
                        Console.WriteLine(dungeonMaster.IsGameOver());
                    }

                }
                catch (Exception e)
                {

                    if(e.GetType().Name == "ArgumentException")
                        Console.WriteLine("Parameter Error: " + e.Message);
                    else
                        Console.WriteLine("Invalid Operation: " + e.Message);

                }
            }
            Console.WriteLine($"Final stats:");
            Console.WriteLine( dungeonMaster.GetStats()); 
            
        }
	}
}