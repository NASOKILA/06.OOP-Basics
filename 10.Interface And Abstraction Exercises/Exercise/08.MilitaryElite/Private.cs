using System;
using System.Collections.Generic;
using System.Text;


//Nasledqva klasa oldier i interfeisa IPrivate
public class Private : Soldier, IPrivate
{
    public decimal Salary { get; }

    public Private(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public override string ToString()
    {
        //Vzimame bazoliq ToString() t.e. tozi na Soldier.cs i kum nego dobavqme oshte salary
        return $"{base.ToString()} Salary: {this.Salary:f2}";
    }

}

