using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private int age;
    private string firstName;
    private string lastName;
    private decimal salary;


    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    

    public Person()
    {

    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }
    
    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} receives {this.salary} leva.";
    }
    
    public void IncreaseSalary(decimal bonus)
    {
        if(this.age >= 30)
            this.salary *= decimal.Parse(("1." + bonus.ToString()));
        else
            this.salary *= decimal.Parse(("1." + (bonus/2).ToString()));
    }
    
}

