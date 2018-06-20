using System;
using System.Collections.Generic;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            

            //NAI VAJNOTO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //KONSTRUKTURA VINAGI TRQBVA DA STOI 'PREDI' PROPERTITATA
            //V C# 'OBJECT' E NAI BAZOVIQ KLAS KOITO VSICHKI KLASOVE NASLEDQVAT AVTOMATICHNO.
            //this. - tekushtiq obekt.
            //base. - bazoviq obekt.
            //virtual - virtualen metod e metod koito moje da bude prezapisvan ot drugi metodi.
            //'new' - S tazi duma mojem da kopirame metodi obache polimorphisma NE raboti.
            //abstract class - abstrakten klas e klas koito ne moje da bude inicializiran i se polzva kato INTERFEIS
            //abstract method - tozi metod jivee samo v abstrakten klas i NQMA TQLO, decata na tozi klas trqbva zaduljitelno da go IMPLEMENTIRAT. 
            //'as' - S neq mojem da kastvame klasove v drugi klasove
            //'is' - S tazi duma mojem da proverqvame tiput na daden klas ili na dva klasa dali suvpadat.
            //s 'override' mojem da prezapisvaame i veche prezapisvani metodi
            
            //'sealed' e kluchova duma koqto ni spira ot nasledqvane t.e. ne mojem da nasledim 'sealed' klas !!!
            //'sealed' moje da se prilaga i vurhu VECHE PREZAPISANI virtualni metodi, t.e. TEZI KOITO IMAT 'override', SLED KOETO NE MOJE VECHE DA SE PREZAPISVAT.
                //Vij poslednite dva metoda

            //V statichni metodi nqmame 'this' zashtoto te nqmat instanciq t.e. te sa bez obekt
            //NE statichnite metodi idvat ot obekti

            //PAMETTA PRI STATICHNITE METODI SE TRIE SAMO PRI IZLIZANE OT PROGRAMATA.
            //PRI NE STATICHNITE E PO RAZLICHNO  !!!

            VAJNO !!!!!!!!!!!!!!!!!!
            PO DOBRE INTERFEISI OT ABSTRAKTNITE KLASOVE !!!
             
             PO PRINCIP V REALNITE PROEKTI NESHTATA STAWAT TAKA:
                01.Imame mnogo interfeisi.
                02.Imame edin BAZOV klas koito gi nasledqva vsichki.
                03.Imame oshte mnogo drugi klasove koito nasledqvat tozi BAZOV klas.
                
            Shte razgledame :
                01.Polymorphisum Definition and Types of Polimorphisum 
                02.Override Methods - virtual, new, hiding definition ...
                03.Overload Methods - znaem go tova
                04.Abstraction - Abstraction methods and classes
            
            01.Polimorphysum
                Kakvo e polimorphisum ? 
                Idva ot grucki ezik : (polys = MNOGO) (Morphe = FORMI)
                i ozn che edno neshto moje da ima mnogo formi
                i da se durji kato mnogo neshta





            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Mojem primerno edin List<T> da go KASTNEM kum:
                    IEnumerable, ICollection, IReadOnlyCollection ... I OSHTE DRUGI
                    ZASHTOTO NASLEDQVA TEZI INTERFEISI
                
            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Soft Cast: 'as' KEYWORD
                    STAVA S KLUCHOVATA DUMA 'as' !!!
                    var animalAsPerson = animal as Person;
                
            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                'is' KEYWORD
                    POLZVAME Q ZA DA PROVERQVAME DALI DADEN KLAS E RAVEN NA DRUG KLAS
                    PROVERQVAME DALI TIPUT IM E EDNAKKUV:
                    if(person is Person){...}

                Posle tozi List<T> zapochva da se durji po razlichen nachin !
            

                Drug primer:
                    Ako edin klas 'Toyota' nasledqva BAZOV KLAS 'Car' koito nasledqva
                    Interfeis 'ITransport' to klasa 'Toyota' moje da se durji kato:
                        01.Toyota
                        02.Car
                        03.ITransport
                        03.Object   -   Zashtoto vsichki go nasledqvat
             */
            Console.WriteLine();

            Person person = new Person(15);
            person.Reproduce();
            Console.WriteLine(person.Age);

            IAnimal person3 = new Person(5);
            person3.Reproduce();
            Console.WriteLine(((Person)person3).Age); //ZA DA POLZVAME .Age OT IAnimal TRQBVA DA GO KASTNEM KUM 'Person' !!!!

            //Ne stawa zashtoto Mammal() e abstrakten klas. 
            //IAnimal person4 = new Mammal();


            Console.WriteLine();
            //Mojem da polzvame i vsichko ot Cat() klasa
            IAnimal cat = new Cat(20);
            //TOV E POLIMORFISUM


            //MOJEM VSICHKI DA GI NABUTAME V EDIN SPISUK:
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(person);
            animals.Add(cat);


            foreach (var animal in animals)
            {
                animal.Reproduce();
                animal.PersonalInfo();

                //SOFT CAST : 'as' KEYWORD !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //kastvame animal kum Person
                Person animalAsPerson = animal as Person;

                // 'is' KEYWORD !!!!!!!!!!!!!!!!!!!!!
                //Proverqvame dali e ot tip Person
                if (animalAsPerson is Person)
                    Console.WriteLine("SOFT CAST 'as' AND 'is' KEYWORDS: " + animalAsPerson.Age);
                Console.WriteLine("-----------------------");
            }


            /*
            Ideqta e da imame obsht interfeis koito da se implementira ot drugi klasove.
            Polymorfizma e DA MOJEM DA POLZVAME TEZI KLASOVE CHREZ SAMIQ INTERFEIS.

             

             Koga da polzvame 'abstract' i koga 'interface' ?
                Polzvame abstract samo kogato iskame da vmuknem i nqkakva logika vuv vseku edin Child klas !
                Inache ako nqma da vmukvame nikakva logika si polzvame interfeis.
                
                NAI DOBRATA PRAKTIKA E DA POLZVAME I DVETE:
                    PRAVIM SI ABSTRAKTEN KLAS KOITO DA IMPLEMENTIRA EDIN ILI POVECHE INTERFEISI !
             */

            /*
             Hiding Methods - SKriVANE NA METoDI
                AKO IMAME SKRIVANE NA DVA MEtoDA SE VZIMA PO DEFaUlt PURVIQ T.E. TOZI KOIto E PO NA GORE V IERARHIQTA.
                TOZI PROBLEM SE OPRAVQ CHREZ 'override' PREZAPISVANE, NO METODA TRQBVA DA E 'virtual' ILI 'abstract' !!! 
             
             */

            /*
             02. Types of polymorphisum:
             
                01.Runtime Polymorphism:
                    Polzvame abstrakten klas za BAZOV KLAS 
                    Abstraktnite klasove ne mogat da se inicializirat
                    ABSTRAKTNIQ KLAS E KATO INTERFEIS, ZADULJITELNO DECATA MU TRQBVA DA IMAT KONSTRUKTOR
                        I AKO IMA ABSTRAKTNI METODI TO DECATA TRQBVA DA GI IMAT SUSHTO.
                    Abstraktniq metod NQMA TQLO(BODY), toi samo se definira i posle se pishe tqloto v decata na abstraktniq klas.
                    Abstraktniq metod jivee SAMO V ABSTRAKTEN KLAS !!!

             */




            //MNOOOOOOOOOOOOOOGO VAJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //'static' - statichen metod e metod koito NE se izvikva ot obekt (instanciq na klas) sledovatelno NQMA KONTEXT !!!
            //dokato 'non-static' e metod koito SE izvikva ot obekt (instanciq na klas) I IMA KONTEXT !!!


            Console.WriteLine();
            Console.WriteLine("Method overloading :");
            /*
             Method overloading:
                Mojem da imame mnogo metodi s edno i sushto ime koito da priemat 
                razlichen tip i broi parametri, i da se izvikva pravilniq metod 
                v zavisimost kakvi i kolko parametura sa podadeni !!!!!!!
            Mojem i da razmestim parametrite.   
            TOVA SE NARICHA METHOD OVERLOADING !!!!!
               
            

            VAJNO!OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!
            TOVA SE NARICHA I:
                02. CompileTime Polymorphisum !!!!!!!!!!!!!!
             */




            Console.WriteLine(Add(5, 10));
            Console.WriteLine(Add(5, 5, 5));
            Console.WriteLine(Add(1.25, 6.6, 10.5));

            //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //S 'params double[] nums' NIE KAZVAME CHE MOJE DA PODAVAME RAZLICHEN BROI PARAMETRI NA FUNKCIQTA !!!
            Console.WriteLine(Add(4.5, 6.1, 97.1, 71.12));


            /*
             Kak raboti Method overloading ? 
                Trqbva signaturata na metodite da e ralichna !
                    SIGNATURA - Tova e IMETO I PARAMETRITE NA METODA, Primerno: Add(int a, int b, int c)
                
                Ako primerno imame int Add(int a, int b)  I  int Add(int a, int b) NQMA DA STANE
                01.Toest trqbva da smenim i tiput ne samo na metoda no i na parametrite.
                02.Mojem da smenqme tiput na argumentite
                03.Mojem da smenqme i podredbata na argumentite no NE E PREPORUCHITELNO
             
                CONTRUCTORS CAN BE OVERLOADED!
             */



            Console.WriteLine();
            Console.WriteLine("Factory Class:");

            /*
             Kakvo e Factory Class ? 
                Klas koiot moje da suzdava instancii na drugi klasove
                MNOGO E UDOBNO ZA POLZVANE ZASHTOTO MOJESH DA IMASH 
                EDIN KLAS KOITO DA SUZDVA OBEKTI OT DRUGI MNOGO KLASOVE !!!!!!!!
             
             */
            DogFactory dogFactory = new DogFactory();
            Dog gafy = dogFactory.CreateDog("Gafy", 9);
            Console.WriteLine(gafy);

            Console.WriteLine();
            Console.WriteLine("Dinamichen polymorfisum:");
            /*
             Dinamichen polymorohysum:
                
                Polzvame 'virtual' za dadeni metodi koito po nadolo mojem da gi prezapisvame !
             */

            Rectangle rect = new Rectangle(15, 5);
            Console.WriteLine(rect.CalculateArea());

            Square square = new Square(15, 5);
            Console.WriteLine(square.CalculateArea());





            /*
             
             NAI VAJNOTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                V EDIN INTERFEIS ABSOLUTNO VSICHKO E ABSTRAKTNO!
                DOKATO V EDIN ABSTRAKTEN KLAS METODITE PRIMERNO TRQBVA DA 
                GI DEFINIRAME KATO ABSTRAKTNI NO MOJE I DA NE SA ABSTRAKTNI.
             
             
             */

            //VAJnooooooooooooooooooooooooo!!!!!!!!!!!!!!!!!!!!!!!!!!
                //V abstrakten klas mojem da slagame Access Modifieri : public, private, protected
                //dokato v interfeisa vsichko e public 
                //mojem da imame i konstruktori poleta metodi i propertita



            /*
             Prezapisvane na metodi:
                Mojem da prezapisvame metod koito veche e prezapisan vednuj !!!!!!!!!!!!!!!!
                t.e. metodi koito veche imat 'override' !!!!

                'private' i 'static' metodi NE moje da se prezapisvat:
                    'private' zashtoto ne moje da se dostupi za da se prezapishe !!!
                    'static' zashtoto nqma kontext t.e. nqma ot kakvo da go prezapishem !!!
             */



        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public static double Add(double a, double b, double c)
        {
            return a + b + c;
        }

        //Sus 'params' pravim taka che metoda da priema neznaen broi parametri !!!!!  
        public static double Add(params double[] nums)
        {
            double sum = 0;
            foreach (var n in nums)
                sum += n;

            return sum;
        }

    }

    public class Rectangle
    {
        public Rectangle(int sideA, int sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        private int sideA;

        private int sideB;

        public int SideA
        {
            get { return sideA; }
            set { sideA = value; }
        }

        public int SideB
        {
            get { return sideB; }
            set { sideB = value; }
        }

        public virtual double CalculateArea()
        {

            Console.WriteLine("Rectangle Area: ");
            var area = this.SideA * this.SideB;
            return area;
        }

    }

    public class Square : Rectangle
    {
        public Square(int sideA, int sideB)
            : base(sideA, sideA) //Podavame mu dva puti SideA za da go izlujem
        { }

        public override double CalculateArea()
        {
            Console.WriteLine("Square Area: ");
            var area = this.SideA * this.SideA;
            return area;
        }


    }

    public class DogFactory {

        public Dog CreateDog(string dogName, int dogAge)
        {
            Dog dog = new Dog(dogName, dogAge);
            return dog;
        }
    }

    public class Dog
    {

        public Dog(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        private string name;

        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.Name} / Age: {this.Age} !";
        }
    }


    public interface IAnimal
    {
        void Reproduce();

        void PersonalInfo();
    }

    public abstract class Mammal : IAnimal
    {
        public void PersonalInfo()
        {
        }

        public void Reproduce()
        {
            Console.WriteLine("I am a Mammal and I can reproduce !");
        }
    }

    //VAJNOOOOOOO !!!!!!!!!!!!!!!!!!!!!!!!
    //V C# 'OBJECT' E NAI BAZOVIQ KLAS KOITO VSICHKI KLASOVE NASLEDQVAT AVTOMATICHNO.
    public class Person : IAnimal
    {
        public int Age { get; set; }

        public Person()
        {
            this.Age = 0;
        }

        public Person(int age)
        {
            this.Age = age;
        }

        public void Reproduce()
        {
            Console.WriteLine($"I am a Person and I Can Reroduce !");
        }


        public void PersonalInfo()
        {
            Console.WriteLine($"I am a Person and I am {this.Age} years old.");
        }

        public override string ToString()
        {
            return base.ToString(); //Cukni F12 vurhu 'base.' I SHTE VIDISH CHE NAI BAZOVIQ KLAS E 'Object'.
        }

    }

    //Kotkata nasledqva IAnimal
    public class Cat : IAnimal
    {
        public int Age { get; set; }

        public Cat()
        {
            this.Age = 0;
        }

        public Cat(int age)
        {
            this.Age = age;
        }

        public void PersonalInfo()
        {
            Console.WriteLine($"I am a Cat and I am {this.Age} years old.");
        }

        //KAKVO E SKRIVANE ?
        //Imame Dva Reproduce() metoda i ediniq se SKRIVA
        public void Reproduce()
        {
            Console.WriteLine("I am a Cat and I can reproduce");
        }
    }

    public sealed class Car
    {}

    public class BMW //: Car   NE MOJEM DA NASLEDIM 'sealed' KLAS Car
    {
        //sus 'sealed' mu kazvame che decata na tozi klas ne mogat da prezapisvat tozi metod !!!
        public sealed override string ToString()
        {
            return "I am driving ..."; 
        }
    }

    public class BMW150 : BMW
    {
        //NE NI DAVA DA PREZAPISHEM ToString() METODA !
    }

}
