using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersToCall = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> sitesToVisit = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var number in numbersToCall)
            {
                Smarthphone smarthphone = new Smarthphone();
                smarthphone.Number = number;
                Console.WriteLine(smarthphone.Calling());
            }

            foreach (var website in sitesToVisit)
            {
                Smarthphone smarthphone = new Smarthphone();
                smarthphone.Website = website;
                Console.WriteLine(smarthphone.Brawsing());
            }


        }
    }
}
