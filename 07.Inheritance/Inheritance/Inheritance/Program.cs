using System;
using System.Collections.Generic;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {


            /*
             Nasledqvane:
                Nasledqvaneto se polzva da ne povtarqme kod 
                Nai vajnite neshta se iznasqt v bazoviq klas a spesifichnite
                za vseki drug klas si ostavat za nego.


            SHTE RAZGLDAME:
                01.Inheritance
                02.Klasove v ierarhiqta
                03.Nasledqvane v C#
                04.Dostup do chlenove na BASE klasa
                05.Koga da polzvame Nasledqvaneto 
                06.Kompoziciq
                Shte razgledame i malko polymorfisum
             

                VAJNO E DA NE KOPIRAME KOD, MOJE DA POLZVAME OTDELNA FUNKCIQ ILI
                OTDELEN KLAS.




            Base Class - Naricha se i Sub Class ili Parent Class
                Toi spodelq poletata i metodite si na negovite deca.


            Sub Class - Naricha se i ChildClass ili Derived Class
                Toi Polzva metodi i poleta ot Bazoviq klas, moje da si gi promenq pri nego
                toi razshirqva bazoviq klas zashtoto moje da si ima i dopulnitelni negovi specifikacii.


            PRIMER:
                BASE CLASS 'Vehicle'
                
                DERIVED CLASSES: 'Car', 'Boat', 'Plane' nasledqvat vehicle
                no moje da si imat i dopulnitelni tehni neshta.
             



            Nasledqvaneto vodi do IERARHIQ OT KLASOVE ILI OT INTERFEISI V DADEN PROEKT.

            Interfeisite ZAOCHVAT SUS 'I' i mogat da nasledqvat drugi interfeisi

            PRIVATE POLETATA NE SE NASLEDQVAT VUOBSHTE NITO PUK SE DOSTUPVAT.

             */




            UniversityTeacher universityTeacher = new UniversityTeacher(10);


            //sega mojem da pravim taka ZASHTOTO universityTeacher nasledqva klasaPErson
            //kakto i klasa Teacher.
            Person person = universityTeacher;
            Teacher teacher = universityTeacher;

            //NO NE MOJE OBRATNOTO!
            //universityTeacher = teacher;
            //MOJEM I DA GI KASTVAME EDNO KUM DRUGO !!!


            //MOJEM DA IMAME METOD PRIMERNO KOITO PRINTIRA ADRESA NA CHOVEK 
            //V ZAVISIMOSt DALI E UCHITeL ILI STUDENt iLI raBOTNIK

            //NA PO OBSHTOTO MOJEM DA SLOJIM PO CHASTnOTO NO NE I OBRATNOTO.

            //REALNO MOJEM I DA SE SPEAVIM I BEZ NASLEDQVANE 


            /*
             VSQKO EDNO NESHTO KOETO E INTERNAL NE MOJE DA SE DOSTUPI OT DRUG PROEKT. 
              
             VAJNO !!!:
                MOJEM DA IMAME PUBLIC KLAS SUS INTERNAL PROPERTY, 
                s.l. OT DRUG PROEKT SHTE MOJEM DA DOSTUPIM KLASA NO NE I 
                PROPERTITO.
                NO MOJE I DA BUDE NASLEDEN OT DRUGI KLSOVE V DRUGI PROEKTI. 
             */


            //ZAPOMNI CHE base NI DAVA DOSTUP DO BAZOVITE POLETA NA KLASA.

            /*
             Multiple Inheritance:
                TOVA E KOGATO EDIN KLAS NASLEDQVA NE EDIN  POVECHE KLASA.
                V C# NQMA MULTIPLE INHERITANCE T.E. TOVA NE E VUZMOJNO.
             
             */

            Console.WriteLine();

            /*
                       Shadowing Variables:
                          Childs Klasovete mogat da kriqt promenlivite na Base klasa.
                          VUPROSA E KOE E S PRIORITET V DADENA SITUACIQ.
            */
            Dog dog = new Dog();
            dog.GetWeight();



            Console.WriteLine();
            /*
             Kakvo e VIRTUAL ? 
             TOVA SUZDAVA METODI KOITO MOGAT DA SE PREZAPISVAT. 
             
                Animal klasa ima virtualen metod koito shte promenimot klasa Cat 
             
             */


            Animal animal = new Animal();
            string animalName = animal.PrintType();
            Console.WriteLine(animalName);

            Cat cat = new Cat();
            string name = cat.PrintType();
            Console.WriteLine(name);

            //SUS 'new' NE GO PREZAPISVAME A GO KOPIRAME V NOVIQ KLAS
            Frog frog = new Frog();
            string frognName = frog.PrintType();
            Console.WriteLine(frognName);



        }



        class Person
        {
            private string privatePersonName { get; set; }
            protected string protectedPersonProperty { get; set; }
            public int publicPersonField { get; set; }
            public int age { get; set; }


            public Person(int age)
            {
                this.age = age;
            }
        }
        
        class Teacher : Person
        {
            private string privateTeacherName { get; set; }
            protected string protectedTeacherProperty { get; set; }
            public int publicTeacherField { get; set; }
            public new int age { get; set; }


            //VAJNO !!! : ZA DA SKRIEM NESHTO OT BAZOVIQ KLAS GO DEKLARIRAME S 'new' !!!!
            //NO NA MOMENTI NE E HUBAVO DA SE PRAVI

            //Ot tuk imame dostup do pubic i protected poletata na klasa Person

            //ZA DA DOSTUPIM POLETATA OT DRUGITE KLASOVE MOJEM DA POLZVAME this.
            //NO MOJEM I SUS base. ZA TEZI NA BAZOVIQ KLAS.
            public void TestTeacherInheritance()
            {

                //Sus base. vijdame samo tezi poleta ot bazoviq klas PERSON
                //SUS this. vijdame vsichki.

                //SETVAME NASHIQ age NA TOZI OT BAZOVIQ KLAS.
                this.age = base.age;

            }


            //Moje da stane i taka KATO GO NASLEDIM OT KONSTRUKTURA NA BAZOVIA KLAS:
            public Teacher(int age): base(age) {



                //tozi konstruktor shte izvika negoviq bazov t.e. tozi na klasa Person

                //setvame go na age ot BAZOVIQ KLAS
                this.age = age;
            }


        }

        class UniversityTeacher : Teacher
        {
            private string privateUniversityTeacherName { get; set; }
            protected string protectedUniversityTeacherProperty { get; set; }
            public int publicUniversityTeacherField { get; set; }
            public int age { get; set; }


            //AKO INICIALIZIRAME TUK TOVA SHT SE IZPULNI PREDI KONSTRUKTURA.
            private List<int> grades = new List<int>();

            public UniversityTeacher(int age): base(age)
            {
                //tozi konstruktor shte izvika negoviq bazov t.e. tozi na klasa Teacher
                this.age = age;
            }

            /*
             Ot tuk imame dostup do pubic i protected poletata na klasa Person
             i tezi na klasa Teacher
            */

        }




        /*
            Shadowing Variables:
               Childs Klasovete mogat da kriqt promenlivite na Base klasa.
               VUPROSA E KOE E S PRIORITET V DADENA SITUACIQ.
               VIJ SLEDNIQ PRIMER:
         */

        class Animal
        {
            protected int weight = 10;

            public virtual string PrintType()
            {
                return ($"Hello I an ANIMAL.");
            }
        }

        class Dog: Animal
        {
            //po princip nqma smisul pak da deklarirame weight zashtoto go imame v bazoviq klas.

            //tova skriva int weight
            protected float weight = 15;

            public void GetWeight()
            {
                //Tova skriva float weight
                double weight = 20d;

                //S PRIORITET E LOKALNATA PROMENLIVA t.e.double weight = 20d;
                Console.WriteLine(weight);

                Console.WriteLine(this.weight); // float weight = 15;

                Console.WriteLine(base.weight); // int weight = 10;

            }

        }

            /*
             Kakvo e VIRTUAL ? 
             TOVA SUZDAVA METODI KOITO MOGAT DA SE PREZAPISVAT. 
             Animal ima virtualen metod PrintType() koito nie ot Cat() 
             klasa shte mojem da prezapishem.
            */
        class Cat : Animal
        {
            //avtomatichno ni izliza !!!!!!!!!
            public override string PrintType()
            {
                return $"Hello I a CAT.";
            }
        }


        //VAJNO !!!! : MOJEM DA POLZVAME 'new' NO TAKA NE GO PREZAPISVAME A GO .
        class Frog : Animal
        {
            //VAJNO !!!!!!!!!!!
            //SUS 'new' SI SUZDAVAME NOV METOD NO NE GO PREZAPISVAME KOPIRAME
            public new string PrintType()
            {
                return $"Hello I a FROG.";
            }
        }





        /*
          Internal:

          VAJNOOOOOOOOOOOOOOOOOOOO !!!!!!!!!
             Za da polzvame internal trqbva da 
             DOBAVIM REFERENIQ KUM TOZI PROEKT
         */

        //StackOfStrings spisuk = new StackOfStrings();
        

        /*
          SUMMARY:
            Inheritance e za da ne povtarqme kod.
            Imame Base klas i Derived ili Child klas

        

          ZAPOMNI DUMITE:  
        
            Virtual - metod koito moje da bud prezapisan ot naslednicite mu, POLZVA SE MNOGO, 
                NE MOJE EDIN KLAS DA E VIRTUALEN NO MOJE DA BUTE ABTRAKTEN.

            new - s nego mojem da kopirame metodi ot Parent klasa, POLZVA SE KOGATAO 
                SKRIVAME METOD OT BAZOVIQ KLAS, MOJE DA SE POLZVA I VURHU NORMALNI METODI 
                KOITO NE SA VIRTUALNI, 
            
            override - ozn prezapisvane,

            this

            base - dava ni dostup do bse klasa 
            
            ':' - Tova e za nasledqvane na klas, 
         */




    }
}
