using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        DraftManager draft = new DraftManager();
        
        while (true)
        {


            try
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = input[0];

                List<string> inputToPass = input.Skip(1).ToList();

                if (command == "RegisterHarvester")
                {
                    Console.WriteLine(draft.RegisterHarvester(inputToPass));
                }
                else if (command == "RegisterProvider")
                {
                    Console.WriteLine(draft.RegisterProvider(inputToPass));
                }
                else if (command == "Day")
                {
                    Console.WriteLine(draft.Day());
                }
                else if (command == "Check")
                {
                    Console.WriteLine(draft.Check(inputToPass));
                }
                else if (command == "Mode")
                {
                    Console.WriteLine(draft.Mode(inputToPass));
                }
                else if (command == "Shutdown")
                {
                    Console.WriteLine(draft.ShutDown());
                    Environment.Exit(0);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }    
    }
}

