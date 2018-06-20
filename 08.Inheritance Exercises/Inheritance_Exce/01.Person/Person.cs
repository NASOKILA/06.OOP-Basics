using System;
using System.Collections.Generic;
using System.Text;

public class Person
{

    const int MIN_NAME_LENGTH = 3;
    const int MIN_AGE = 0;

    private string name;
    private int age;

    public Person()
    {}

    public Person(string name , int age)
    {
        this.Name = name;
        this.Age = age;
    }
    
    public virtual string Name
    {
        get { return name; }
        set
        {
            if (value.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            name = value;
        }
    }

    public virtual int Age
    {
        get { return age; }
        set
        {
            if(value < MIN_AGE)
            {
                throw new ArgumentException("Age must be positive!");
            }

            age = value;
        }
    }


    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }

}

