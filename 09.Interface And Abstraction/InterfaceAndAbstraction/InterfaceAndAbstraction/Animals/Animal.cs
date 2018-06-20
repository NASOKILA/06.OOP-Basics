using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Animals
{
    public abstract class Animal
    {

        /*
            Animal sudurja vsichki obshti harakteristiki na vsichki jivotni.
            TOVA SE NARIHA ABSTRAKTEN KLAS.
            I CHREZ NEGO PESTM MNOGO POVTARQNE NA KOD I SAMATA LOGIKA E MNOGO 
            PO LESNA.
                
             
            VAJNOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!
                Dobavqiki dumichkata 'abstract' nie nqma da mojem da suzdavame poveche
                instancii na tozi klas.
             */
         
        public string Name { get; set; }

        public int Age { get; set; }


        /*Abtrakten metod:
            ZADULJITELNO SE NAMIRA V ABSTRAKTEN KLAS
            TOI MOJE SAMO DA SE PREZAPISVA OT DECATA NA TOZI KLAS
            ABSTRAKTNIQ KLAS NE MOJE DA IMA TQLO. 
            
            VAJNO !!!!
                DECATA NA TOZI KLAS SA ZADULJENI DA PREZAPISHAT ABSTRAKTNIQ METOD.
         
         */


        //abstrakten metod
        public abstract void Sound();


        //moje i da polzvame 'virtual' 



        //normalen metod
        public void Eat() {
            Console.WriteLine("I am eating !");
        }



    }
}





