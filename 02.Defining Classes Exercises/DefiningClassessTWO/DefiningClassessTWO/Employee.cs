using System;
using System.Collections.Generic;
using System.Text;


public class Employee
{
    
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    private decimal salary;
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    private string position;
    public string Position
    {
        get { return position; }
        set { position = value; }
    }


    private Department department;
    public Department Department
    {
        get { return department; }
        set { department = value; }
    }


    private int age;
    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    private string email;
    public string Email
    {
        get { return email; }
        set {  string email = value; }
    }


    public Employee()
    {}

    public Employee(string name, decimal salary, string position, 
         string email = "n/a", int age = -1)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.email = email;
        this.age = age;
    }

}

