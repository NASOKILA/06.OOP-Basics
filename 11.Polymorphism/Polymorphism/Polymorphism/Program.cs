using System;
using System.Collections.Generic;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            

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
            Console.WriteLine(((Person)person3).Age); 
			
            Console.WriteLine();
            IAnimal cat = new Cat(20);
  
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(person);
            animals.Add(cat);


            foreach (var animal in animals)
            {
                animal.Reproduce();
                animal.PersonalInfo();

                Person animalAsPerson = animal as Person;

                if (animalAsPerson is Person)
                    Console.WriteLine("SOFT CAST 'as' AND 'is' KEYWORDS: " + animalAsPerson.Age);
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine();
            Console.WriteLine("Method overloading :");   
            Console.WriteLine(Add(5, 10));
            Console.WriteLine(Add(5, 5, 5));
            Console.WriteLine(Add(1.25, 6.6, 10.5));
            Console.WriteLine(Add(4.5, 6.1, 97.1, 71.12));
            Console.WriteLine();
            Console.WriteLine("Factory Class:");

            DogFactory dogFactory = new DogFactory();
            Dog gafy = dogFactory.CreateDog("Gafy", 9);
            Console.WriteLine(gafy);

            Console.WriteLine();
            Console.WriteLine("Dinamichen polymorfisum:");
           
            Rectangle rect = new Rectangle(15, 5);
            Console.WriteLine(rect.CalculateArea());

            Square square = new Square(15, 5);
            Console.WriteLine(square.CalculateArea()); 
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
            : base(sideA, sideA) 
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
            return base.ToString(); 
        }
    }

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

        public void Reproduce()
        {
            Console.WriteLine("I am a Cat and I can reproduce");
        }
    }

    public sealed class Car
    {}

    public class BMW
    {
        public sealed override string ToString()
        {
            return "I am driving ..."; 
        }
    }

    public class BMW150 : BMW
    {}
}