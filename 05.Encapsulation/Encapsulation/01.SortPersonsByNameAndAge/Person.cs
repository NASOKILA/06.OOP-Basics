using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private int age;
    private string firstName;
    private string lastName;

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

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is {this.age} years old.";
    }
    
    public Person()
    {

    }
    
    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

}

