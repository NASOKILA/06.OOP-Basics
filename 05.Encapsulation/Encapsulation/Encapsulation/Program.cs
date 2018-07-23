using System;
using System.Collections.Generic;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
           
             
             Encapsulation:


                01.What is Encapsulation:
                    Trqbva da znaem samo neshtata koito sa ni nujni da znaem.
                    Ideqta ne e da se skrie koda a da ni e po prosto kato imame
                    dostup samo do tova koeto ni e nujno.
                    
                    Pri enkapsulaciqta poletata trqbva da sa private
                    osven neshtata koito iskame da se dostupvat.
                    PO DEFAULT EDNO POLE E private NO E HUBAVO DA SE PISHE.
                    
            Internal e kato public samoche za nastoqshtiq proekt.
            Imame geteri i seteri, no moje i da nqmame seter.

            
        //Setera moje da private SLEDOVATELNO NQMA DA MOJEM DA GO DOSTUPI OTVUN KLASA I DA SETVAME
        //Moje i da nqma seter
        //S METOD KOITO DA NI SLUJI KATO SETER MOJEM DA NAPRAVIM POVECHE!
             */
            Console.WriteLine();
            
            var person = new Person();
            person.Age = 2;

            person.IncreaseAgeByOne();
            Console.WriteLine(person.Age);

            Console.WriteLine();

            int? something = null;

            Console.WriteLine();

            string myString = "old string";
            Console.WriteLine(myString);

            myString.Replace("old", "new");
            Console.WriteLine(myString);

            Console.WriteLine("Stariq string si ostava sushtiq !!!!!!!!!!!");
          
            string newString = myString.Replace("old", "new");
            Console.WriteLine(newString);
            Console.WriteLine("Sega veche se promenq !!!!!!!!!!!!!!");

            Console.WriteLine();
          
                 VAJNO E DA GO ZNAEM TOVA KOGATO RABOTIM S KOLEKCII, DA 
                 GLEDAME KAKVO NI VRUSHTA KOLEKCIQTA.



                VAJNO !!!!!!!!!!!!!!!!!!!
                    Pass by Value 
                    Pass by Reference   -   RABOTIM SUS OBEkta V PAMETTA
             

            
                VAJNO !!!!!!!!!!!!!!!!!!!    
                    Ako imame mnogo private obekti koito sochat kum daden obekt v pametta
                    nie ne mojem da dostupim private obektite NO MOJEM DA DOSTUPIM 
                    OBEKTA V PAMETTA I AKO GO PROMENIM NEGO SE PROMENQT AVTOMATICHNO I 
                    VSICHKI OBEKTI KOITO SOCHAT KUM NEGO NEZAVISIMO DALI SA PRIVATE.

                NQKOLKO OBEKTA MOGAT DA SOCHAT KUM EDIN OBEKT V PAMETTA !!!
                NE E SLOJNO ZA RAZBIRANE !  

                    AKO IMAME EDIN SPISUK KOITO PRIMERNO E PRIVATE, NIE NE
                    MOJEM DA GO SETVAME NA NOV SPISUK NO MOJEM DA MU 
                    PROMENIM STOINOSTITE AKO TE SA PUBLIC  !!!!!!

            
            //team.ReserveTeam = new List<Person>();         //TO E SAMO REAONLY TOVA NE E POZVOLENO

            //team.FirstTeam.Clear();   //MOJEM DA IZVIKAME .Clear() I POSLE .AddPlayer() I DA DOBAVQME PLAYERI
            //ZA DA SE ZASHTITTIM OT TOVA MOJEM DA MAHNEM PUBLIC POLEtATA I DA SI NAPRAVIM PUBLIC READONLY COLLECTION
            //I POSLE NQMA DA MOJEM DA IZVIKAME .Clear();
             */
            Console.WriteLine();
        }

        public static void getNum()
        {}
    }
}
