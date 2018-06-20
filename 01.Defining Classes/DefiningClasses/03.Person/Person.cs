using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    //fields
    private string name;

    private int age;

    private List<BankAccount> accounts;
        

    //construktors

    /*public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        this.accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        this.accounts = accounts;
    }
    */


    //Mojem da polzvame konstruktor chaining :
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        accounts = new List<BankAccount>();
    }

    //TOZI KONSTRUKTOR SHTE IZVIKA POREDISHNIQ  SPORED PARAMETRITE !!!
    public Person(string name, int age, List<BankAccount> accounts)
        :this(name, age)
    {
        this.accounts = accounts;
    }
    

    //Methods
    public decimal GetBalance() {
        //returns the sum of all accounts balances
        return this.accounts.Select(ac => ac.Balance).Sum();
    }

    

}



