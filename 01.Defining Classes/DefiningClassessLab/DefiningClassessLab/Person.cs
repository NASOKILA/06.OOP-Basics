
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    public Person()
    {

    }

    //nasledqva purviq konstruktor
    public Person(string name, int age)
        :this()
    {
        this.name = name;
        this.age = age;
        this.Accounts = new List<BankAccount>();
    }

    //nasledqva vrotiq konstruktor
    public Person(string name, int age, List<BankAccount> accounts)
        :this(name, age)
    {

        this.name = name;
        this.age = age;
        this.accounts = new List<BankAccount>();
    }

    private string name;

    private int age;

    private List<BankAccount> accounts;


    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            this.age = value;
        }
    }

    public List<BankAccount> Accounts
    {
        get { return this.accounts; }
        set
        {
            this.accounts = value;
        }
    }


    public double GetBalance() // get balance from all accounts
    {
        return this.accounts.Select(a => a.Balance).Sum();
    }

}










