using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    string name;

    int age;

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int age): this()
    {
        this.age = age;
    }

    public Person(string name, int age): this(age)
    {
        this.name = name;
    }
}