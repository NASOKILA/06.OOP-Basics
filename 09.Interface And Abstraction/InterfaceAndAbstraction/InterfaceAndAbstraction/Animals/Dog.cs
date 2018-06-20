using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Animals
{
    public class Dog: Animal
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
            Console.WriteLine("Bau Bau !");
        }


        //kopirame go
        public new void Eat() {

            //izvikvame si tova ot bazoviq
            base.Eat();
        }

    }
}
