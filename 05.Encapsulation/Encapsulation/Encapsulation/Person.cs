using System;
using System.Collections.Generic;
using System.Text;


public class Person
{

    private string firstName;
    private string lastName;
    private int age;

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
    
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string FullName
    {
        get { return this.firstName + " " + this.lastName; }
    }

    public Person IncreaseAgeByOne() {

        this.age++;
        return this; 
    }

    static public bool ValidateAge(int age)
    {
        return age >= 0;
    }

    public Person()
    {}
}
