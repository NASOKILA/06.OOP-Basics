using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Cars
{
    public class Opel : Car
    {
        //Ne mojem da prezapishem Start() metoda sus 'override' zashtoto ne e virtualen ili bastracten !
        //sega si kopirame Start() metod SUS 'new'
        public new void Start() {
            Console.WriteLine("Opel started !");
        }
    }
}
