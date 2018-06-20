using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Animals
{

    public class Cat: Animal
    {

        /*
         VMESTO DA PISHEM I TUK PROPERTITE PROSTO NASLEDQVAME
         KLASA Animal, TAKA SPESTQVAME KOD.
         
         public string Name { get; set; }

         public int Age { get; set; }
        
         */

        //TUI KATO METODA E ABSTRAKTEN TRQBVA DA IMAME 'override' OTPRED.
        public override void Sound()
        {
            Console.WriteLine("Meow Meow !");
        }




        //lichen metod samo za tozi klas
        public void Sleep() {

        }

    }
}
