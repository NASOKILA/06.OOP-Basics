using System;
using System.Collections.Generic;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityTeacher universityTeacher = new UniversityTeacher(10);

            Person person = universityTeacher;
            Teacher teacher = universityTeacher;

            Console.WriteLine();

            Dog dog = new Dog();
            dog.GetWeight();

            Console.WriteLine();
           
            Animal animal = new Animal();
            string animalName = animal.PrintType();
            Console.WriteLine(animalName);

            Cat cat = new Cat();
            string name = cat.PrintType();
            Console.WriteLine(name);

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

            public void TestTeacherInheritance()
            {
                this.age = base.age;
            }
			
			public Teacher(int age): base(age) {
				
                this.age = age;
            }
        }

        class UniversityTeacher : Teacher
        {
            private string privateUniversityTeacherName { get; set; }
            protected string protectedUniversityTeacherProperty { get; set; }
            public int publicUniversityTeacherField { get; set; }
            public int age { get; set; }

            private List<int> grades = new List<int>();

            public UniversityTeacher(int age): base(age)
            { 
                this.age = age;
            }
        }

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
            protected float weight = 15;

            public void GetWeight()
            {
                double weight = 20d;

                Console.WriteLine(weight);

                Console.WriteLine(this.weight); 

                Console.WriteLine(base.weight); 
            }
        }

        class Cat : Animal
        {
            public override string PrintType()
            {
                return $"Hello I a CAT.";
            }
        }

        class Frog : Animal
        {
            public new string PrintType()
            {
                return $"Hello I a FROG.";
            }
        }
    }
}
