using System;
using System.Collections.Generic;
using System.Text;

public class Person
{

    const decimal MIN_SALARY = 460;
    const int MIN_AGE = 1;
    const int MIN_NAME_LENGTH = 3;

    private int age;
    private string firstName;
    private string lastName;
    private decimal salary;

    
    public string FirstName
    {
        get { return firstName; }
        set
        {
            firstName = value;

            //Polzvame '?' za da ne ni grumne v sluchi che firstName ni e null
            if (this.firstName?.Length < MIN_NAME_LENGTH || this.firstName == null)
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            lastName = value;
            //Polzvame '?' za da ne ni grumne v sluchi che firstName ni e null
            if (this.lastName?.Length < MIN_NAME_LENGTH || this.lastName == null)
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            
        }
    }

    public decimal Salary
    {
        get { return salary; }
        set
        {
            //V KONSTRUKTORA E VALIDACIQTA
            salary = value;
        }
    }


    public int Age
    {
        get { return age; }
        set
        {
            //VALIDACIQTA E V KONSTRUKTORA
            age = value;
        }
    }



    public Person()
    {

    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;

        //Validaciqta moje i da se napravi tuka V SETERA A MOJE I V OTDELEN METOD !
        this.age = age;
        if (this.age <= MIN_AGE)
            throw new ArgumentException("Age cannot be zero or a negative integer!");

        this.salary = salary;
        if (this.salary < MIN_SALARY)
            throw new ArgumentException("Salary cannot be less than 460 leva!");
        
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} receives {(this.salary / 100).ToString("F2")} leva.";
    }

    public void IncreaseSalary(decimal bonus)
    {
        if (this.age >= 30)
            this.salary *= decimal.Parse(("1." + bonus.ToString()));
        else
            this.salary *= decimal.Parse(("1." + (bonus / 2).ToString()));
    }
    
}