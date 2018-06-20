using InterfaceAndAbstraction.Animals;
using InterfaceAndAbstraction.Arms;
using InterfaceAndAbstraction.Cars;
using InterfaceAndAbstraction.Food;
using System;
using System.Collections.Generic;

namespace InterfaceAndAbstraction
{
    class Program
    {
        static void Main(string[] args)
        {


            /*
             Interfaces And Abstraction:
                Tova e malko po trudno, 
                pravi koda po slojen i se uchi s mnogo pisane na kod.


            Shte ovorim za :

            01.Abstraction - Oznachava da vzimame samo neshtata KOITO NI TRQBVAT. 
                Primer: Ako se zanimavame s mebeli i SME ZAVOD, nas ni interesuva
                primerno ot kakuv material i kak sa napraveni tezi mebeli.
                OBACHE AKO SME MAGAZIN ZA MEBELI, ni interesuvat vuvsem razlichni
                neshta, kato cenata DeDeSe-to i t.n.
                Abstrakciqta e tochno tova, da polzvame SAMO TEZI PROPERTITA OT 
                DADEN OBEKT KOITO NI INTERESUVAT.
                Tova e s cel da ne se povtarq kod.
            
            
            02.Namespace
                Namespace a tak kudeto se namirame v proekta.
                Tova e kato karta koqto ni sochi kude se namirame v samiq proekt.
                Ako imame papka 'Animals' i v neq imame klas 'Dog'
                Namespace-a shte e Animal.Dog{...}

                KATO DADEM . + space VIJDAME VSICHKI OPCII OT VISUAL STUDIO ZA TOZI 
                NAMESPACE V KOITO SE NAMIRAME. 
                AKO NQMASHE NAMESPACE-ove VIUAL STUDIO SHTESHE DA NI ZABIE V OPIT DA 
                NI POKAJE VSICHKI VUZMOJNI BIBLIOTEKI.


            03.Abstrat Class - 
                AKO IMAME TRI KLASA Dog.cs Cat.cs i Bunny.cs KOITO IMAT 'Name' i 'Age'
                Vmesto da gi pishem po otdelno i v trite klasa mojem da gi iznesem v 
                otdelen klas 'Animal' koito da bude nasledqvan ot Dog.cs Cat.cs i Bunny.cs
                V TAKUV SLUCHAI 'ANIMAL' SE NARICHA ABSTRAKTEN KLAS.
                
            
            VAJNOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!
                Celta obache na tozi klas e SAMO DA BUDE NASLEDEN, A NE DA RABOTIM S NEGO
                ZATOVA ZA ABSTRAKTNI KLASOVE SE SLAGA DUMATA 'abstract' PRI DEKLARACIQTA IM.
                SLED TOVA NIE NQMA DA MOJEM POVECHE DA INSTANCIRAME OBEKT OT TOZI KLAS.
            
                Dobavqiki dumichkata 'abstract' nie nqma da mojem da suzdavame poveche
                instancii na tozi klas.
                
            ABSTRAKTNIQ KLAS NE MOJE DA BUDE INSTANCIRAN.
                //Animal animal = new Animal();
            
            
            04.Abstrakten Metod - 
            Tova e metod KOITO SUSHTESTVUVA SAMO V ABSTRAKTEN KLAS.
                
                TOI ZADULJITELNO E PREZAPISVAN SUS 'override' OT KLASOVETE KOITO 
                NASLEDQVAT TOZI ABSTRAKTEN KLAS,
            VAJNO !!!
                ABSTRAKTNIQ METOD NQMA TQLO (body), DEKLARIRA SE BEZ TQLO:
                    public abtrdact void SayHello(); 
                
            
            05.Polymorphism -
                Prez BAZOV klas nie MOJEM da polzvame LOGIKATA na nqkoi ot DECATA mu.        
                LESNO I PROSTO. 
            */

            Console.WriteLine("ANIMALS -----------------------------------------");
            //Obache vijdame samo obshtite propertita na Cat() i Animal() klasovete.
            //ostaaloto NE mojem da go dostpim.
            Animal someAnimal = new Cat();

            //someAnimal.              metoda Sleep() koito e v Cat() klasa NE mojem da go vidim ZASHTOTO SI E SAMO ZA Cat KLAS.

            someAnimal.Sound(); 
            //No mojem da izvikame Sound() metoda koito se prezpisva ot  Animal()
            //INTERESNOTO E CHE IZPISVA 'Meow meow!' KOETO E OT METODA NA Cat() klasa.
            //TOVA E POLIMORFISUM.


            Console.WriteLine();
            //OBACHE ZASHTO PROSTO NE NAPISHA Cat someAnimal = new Cat(); ???
            //Ami primerno ako iskame slednoto:




            Animal animalType = new Dog();
            animalType.Sound();   //pokazva Bau Bau ! ZNACHI IMA POLYMORFISUM




            Console.WriteLine();
            List<Animal> listOfAnimals = new List<Animal>();

            listOfAnimals.Add(new Cat());
            listOfAnimals.Add(new Dog());
            listOfAnimals.Add(new Frog());

            foreach (var animal in listOfAnimals)
            {
                //TOK IDVA POLIMORFIZMA : ZA VSQKO JIVOTNO MU IZVIKVAME Sount() METODA.
                animal.Sound();
            }


            //PAK IZPOLVAME TEHNITE PREZAPISANI PROPERTITA OT BAZOVIQ KLAS 
            //PREZ SAMIQ BAZOV IM KLAS.

            //TOVA E POLYMORFISUM, PREZ ABSTRAKTNIQ KLAS DA POLZVAME PROPERTITATA NA NEGOVITE DECA !!!

            

            Console.WriteLine();
            /*
                Vajno : Sus :
                base()  -  izvikvame neshtata ot bazoviq klas.
                override  -  prezapisvame metod, toi trqbva da e 'virtual' ili 'abstract'
                new  -  kopirame metod no ne go PREZAPISVAME, metoda moje i da e normalen
             */
             
            Dog dog = new Dog();
            dog.Eat();




            //VAJNOOOOOOOOOOOOOO !!!!!!!!!!!!!!!!!!!!!!!!!!
                //Ako polzvame 'new' za da kopirame metodite vmesto da gi prezapisvame
                //POLYMORFIZMA NQMA DA RABOTI.
                //ZA DA RABOTI POLIMORFIZMA TRQBVA DA IMAME 'virtual' ILI 'abstract' METODI.
            Console.WriteLine();

            Console.WriteLine("CARS --------------------------------------------");
            //Cars:

            //kopirame sus 'new' !
            Opel opel = new Opel();
            opel.Start();

            Bmw bmw = new Bmw();
            bmw.Start();

            Fiat fiat = new Fiat();
            fiat.Start();




            //Sega probvame polymorfisma za da vidim che NQMA da proraboti.
            Console.WriteLine();
            Car car = new Opel();

            car.Start(); //IZVIKVA 'Car started !' VMESTO 'Opel started !'  !!!!!!!!!!!!!!!!!!
                         //IZVIKVA METODA NA KLASA Car().


            //AKO NAPRAVIM Start() METODA S 'virtual' I POSLE GO PREZAPISHEM 
            //S 'override' SHTE STANE I SHE IMAME POLYMORFISM.







            /*
             NAI VAJNOTO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                'sealed' OZNACHAVA ZABRANA.
                AKO E NA KLAS OZNACHAVA CHE NIKOI NE MOJE DA GO NASLEDQVA.
                AKO E NA METOD OZNACHAVA CHE NIKOI NE MOJE DA GO PREZAPISVA.
            
                'const' zname kakvo e, tova e neshto koeto ne moje da se promenq.

                'readonly' e kato 'const' samoche moje da se promenq samo ot konstruktura.
                VIJ 'Car.cs' KLASA.  
             */



            Console.WriteLine();

            Console.WriteLine("FOOD -------------------------------------------");
            /*
             06.Interfaces - 
                vsichki interfeisi zapochvat sus 'I'
                Ideqta na interfeisite e da imat samo DEFINICII KAKVO TRQBVA DA IMA VSEKI KLAS KOITO GI NASLEDQVA !!!!!
                TUK VSICHKO E ABSTRAKTNO t.e. NE MOJEM DA GO POLZVAME A SAMO DA GO DEFINIRAME.
                I POSLE DA SE POLZVA OT DRUGI KLASOVE.

                V INTERFEISA VSICHKO E PUBLIC PO DEFAULT ZATOVA NE PISHEM NISHTO OTPRED.
                
            
                MNOGO VAJNOOOOOOOOOOOOOOOOOO !!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    EDIN INTERFEIS MOJE DA NASLEDQVA I DRUGI INTERFEISI.
                    EDIN KLAS MOJE DA NASLEDQVA POVECHE OT EDIN INTERFEIS        
                    

                ZADULJITELNO TRQBVA DA GO IMPLEMENTIRAME avtomatochno VU VSEKI KLAS KOITO SHTE GO POLZVA !!!
                INTERFEISA SAMO OPISVA !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Zashto sa ni nujni ? 
                AMI ZARADI 
                01.POLIMORFISMA  -  PAK MOJEM DA POLZVAME POLIMORFISUM
                02.Pestene na kod,
                03.Po podredeno e vsichko i imame poveche kontrol

            */

            //POLYMORFISUM S INTERFEIS:
            //Pravim si spisuk s takuv interfeis
            List<IFood> foods = new List<IFood>();

            foods.Add(new Meat("Fish", (decimal)10.99, (decimal)2.55));
            foods.Add(new Chips("Pomber", (decimal)3.99, (decimal)0.80));
            foods.Add(new Meat("Beans", (decimal)6.99, (decimal)1.20));

            foreach (var food in foods)
                food.Information();

            //VIJDAME CHE IMAME POLIMORFISUM !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            /*
             VAJNO !!!!
                AKO IMAME NESHTO SPESIFICHNO TOGAVA E DOBRE DA POLZVAME ABSTRAKTEN KLAS   
                INACHE V POVECHETO SLUCHAI E PO DOBRE INTERFEISA.

             */






            Console.WriteLine();
            Console.WriteLine("ARMS --------------------------------------------");
            //ARMS:
            //SHTE POLZVAME POLIMORFISUM ZA VSEKI INTERFEIS:

            //Interfeisut IPIstol nasledqva IArms
            //Obache IKnives NE nasledqva IArms
            
            List<IArms> arms = new List<IArms>();
                arms.Add(new Knive("Knife", 0, 0.60));
                arms.Add(new Pistol("Knife", 0, 0.60));
                arms.Add(new Shoutgun("Knife", 0, 0.60));

            foreach (var arm in arms)
                Console.WriteLine(arm.PrintInfo());

            Console.WriteLine();
            //Pistoletite nasledqvat interfeisa IPistols koito nasledqva IArms
            List<IPistols> pistols = new List<IPistols>();
                pistols.Add(new Barrera("8mm Barrera", "Germany", "Barrera", 12, 0.80));
                pistols.Add(new Barrera("Deasert Eagle 3.5", "Switserland", "Deasert Eagle", 7, 1.20));
            
            foreach (var pistol in pistols)
                Console.WriteLine(pistol.PrintInfo());

            Console.WriteLine();

            //VSEKI NOJ NASLEDQVA DVA INTERFEISA IArms I IKnives
            List<IKnives> knives = new List<IKnives>();
                knives.Add(new ButterflyKnive("Peperutka", 0, 0.50, 20, "Black"));
                knives.Add(new AutomaticKnife("Avtomatichen", 0, 0.40, 15, "White"));

            foreach (var knive in knives)
                Console.WriteLine(knive.PrintInfo());
            







            /*
             Interface Segregation:
                Oznachava da imame kolkoto mojem poveche interfeisi s kolkoto
                mojem po malko metodi i propertita v tqh ZA PO QSEN I LESEN KOD.
             
                MOJEM EDIN GOLQM INTERFEIS DA GO RAZCEPIM NA NQKOLKO PO MALKI !!!
             */





        }
    }
}
