using System;
using System.Collections.Generic;
using System.Text;


public class Student
{

    private string name;

    private int age;

    private double grade;

    private string comment;


    public string Comment
    {
        get { return comment; }
        set { comment = value; }
    }
    
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

    public double Grade
    {
        get { return grade; }
        set { grade = value; }
    }


    public Student()
    {

    }
    
    public Student(string name, int age, double grade, string comment)
    {
        this.Name = name;
        this.Age = age;
        this.Grade = grade;
        this.Comment = comment;

    }
   

    public override string ToString()
    {
        return $"{name} is {age} years old. {comment}";
    }


}   

