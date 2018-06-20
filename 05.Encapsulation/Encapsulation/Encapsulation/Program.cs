using System;
using System.Collections.Generic;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
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

            /*
                02.Keywort this
                    Znaem kakvo e 'this' v konstruktor
                    Sochi kum nastoqshtiq obekt
                    NQMA 'this' VUV statichni metodi TAM VECHE SI GO IMA.
                    Moje da se podava na normalni metodi no nqma smisul zashtoto 
                    tam si go ima !!!
            */

            person.IncreaseAgeByOne();
            Console.WriteLine(person.Age);

            Console.WriteLine();

            /*
            //CALCULATED PROPERTY:
            //Tova e property koqto Nqma Setter i polzva poletata ot klasa
            public string FullName
            {
                get { return this.firstName + " " + this.lastName; }
            }


            //STATIC METODI:
                Polzvat se kogato metoda ne zavisi ot nishto svurzano s klasa


            
            //Konstruktora e METOD NA KLASA
                Konstructor Chaining veche znaem kakvo e, edin konstruktor da izvikva drugite.


                03.Access Modifiers
                    TOVA SA :
                        01.private  -  Skrivme detailite, poleta i funkcii koito 
                            potrebitela na tozi klas ne e nujno da znae !!!
                            Moje i da se pravqt private klasove NO NE SE POLZVA MNOGO V PRAKTIKATA.
                            POLZVA SE ZA KLAS KOITO POLZVA DRUG KLAS KOITO SI E SAMO ZA NEGO I E PRIVATE
                            I TRQBVA DA SUZDADEN VUTRE V PURVIQ KLAS.
                        
                        02.public
                            TOVA GO ZNAEM !!!!!!!!
                            DOSTUPNO E ZA VSICHKI .NET PROGRAMI
                            Nqma nikakvo ogranichenie Dostupno e za celiq solution

                        03.protected
                            Mojem da dostupvame protekted poleta samo ot klasove napraveni naslednici
                            no ne i ot tezi izvun nego.
                            TOVA E KTO PRIVATE SAMOCHE E DOSTUPNO I ZA NASLEDNICITE NA KLASA.
                            POLZVA SE PRI NASLEDQVANE ZA DA SE DADE DOSTUP NA KLASOVETE KOITO SA NASLEDNII !!!
                        04.internal
                            PO DEFAULT EDIN KLAS E internal
                            Moje da se prilaga na metodi i poleta koito shte 
                            sa dostupni samo za klasove v sushtiq proekt.
                            SAMO V RAMKITE NA EDNA BIBLIOTEKA/PROEKT, TAM VSE EDNO E PUBLIC A 
                            IZVUN PROEKTA E KATO PRIVATE, VSE EDNO GO NQMA.
                VAJNO !!!
                    PRI KLASOVETE SE IZBEGVAI DA SLAGASH PRIVATE ILI PROTETED !

            
                04.State Validation
                    V SETERA na poletata mogat da se polzvat za SIMPLE VALIDATION
                    No mojem i da validirame direktno v konstruktura ZASHTOTO 
                    KONSTRUKTURITE SI IMAT PRIVATE SETTERS (Lichni seteri koito samo te si polzvat).

                    AKO VALIDACIQTA E PO SLOJNA KATO NAPRIMER BURKANE V BAZATA E DOBRE DA SE IZKARVA V OTDELEN
                    METOD PRIMERNO S IMA Validate(){ ... }; KOITO DA NI PRAVI VALIDACIQTA.
                    S FUNKCIQ MOJEM DA SPESTIM KOD !!!

                    NAI DOBRE E ZA NQKOI NESHTA (VALIDACII) DA POLZVAME GOTOV ATTRIBUT !!! 

                    VAJNO !!!
                        Ako imame something.length; OBACHE 'something' e NULL PROGRAMATA SHTE GRUMNE,
                        OBACHE NIE MOJEM DA POLZVAME  '?' S KOETO NQMA DA 
                        NI GRUMNE PROGRAMATA.
                        T.E: something?.length;    SHTE VURNE 0 ZASHTOTO E DEFAULTNA STOINOST. 

            */

            int? something = null;

            /*

                    VAJNO !!!
                        MNOGO LOSHA PRAKTIKA E DA SLAGAME PROSTO NOMERA V NASHITE IFOVE ELSOVE CIKLI I t.n.
                        IZVEJDAT SE V KONSTANTI V NCHALOTO NA KLASA:
                            const int MIN_AGE = 0;
                        I SEGA MOJEM DA GO PRILOJIM ZASHTOTO E MNOGO PO RAZBIRAEMO !!!

                05.Mutable and Immutable Objects
                    Tova sa obekti koito mojem ILI KOITO NE MOJEM DA PROMENQME !!!
                    String e IMMUtaBLE OBJECT t.e. NE MOJEM DA PROMENIM SAMIQ OBEKT I ZATOVA 
                    SUZDAVAME NOV.    DOKATO Integer MOJEM DA GO PROMENQME KOGATO SI ISKAME.
             */
            Console.WriteLine();

            string myString = "old string";
            Console.WriteLine(myString);

            myString.Replace("old", "new");
            Console.WriteLine(myString);

            Console.WriteLine("Stariq string si ostava sushtiq !!!!!!!!!!!");
            //Stariq string si ostava sushtiq

            //za da go promenim trqbva da go assignem na nova promenliva
            string newString = myString.Replace("old", "new");
            Console.WriteLine(newString);
            Console.WriteLine("Sega veche se promenq !!!!!!!!!!!!!!");

            Console.WriteLine();
            /*
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
        {
            //Nqma 'this' v statichni metodi
        }




        /*
         Summary:
            Encapsulation: skriva neshtata koito ne sa nujni da se polzvat,
                po oprosteno e taka.

            Validation: Pravi se v Settera, 
                KOnstruktura , 
                v otdelen metod 
                ili s ATRIBUT (Annotations) 
            
            Access Modifiers: 
                public  -  Dostupno za celiq solution, 
                private  -  Dostupno samo v dadeniq klas, 
                internal  -  Po default klasovete sa internal, tova e kato publik NO SAMO 
                    ZA TEKUSHTIQ PROEKT, NE MOJE DA SE DOSTUPI OT DRUG PROEKT V SUSHTIQ SOLUTION, 
                protected  -  Tova e kato private samoche e dostupno i za decata na tozi klas, t.e. tezi koito go nasledqvat. 

            Immutable Objects:
                Stringa e immutable t.e. ne moje da se promeni a trqbva da se setne na nov string, Integer NE 
                e Immutable t.e. mojem da go promenim kogato si iskame

            Mutable Objects:
                Pass By Reference: Ako imame neshto v spisuk, opashka, masiv, steck ili dr. i AKO GO PROMENIM
                SHTE VIDIM CHE NA VSQKUDE SE PROMENQ

                Pass By Value: Ako imame spisuk i setnem nov spisuk na stariq i ako promenim malko noviq 
                to stariq NQMA DA SE PROMENI ZASHTOTO E PASS BY VALUE.

                AKO IMAME DVA SPISUKA S EDNAKVI ELEMENTI TO TOVA OZNACHAVA CHE TE SOCHAT KUM EDNI I SUSHTI OBEKTI V 
                PAMETTA. I AKO MOJEM DA DOSTUPIM TEZI OBEKTI (Po reference) I DA GI PROMENIM TO I TEZI V SPISUCITE SHTE SE 
                PROMENQT.

         */


    }
}
