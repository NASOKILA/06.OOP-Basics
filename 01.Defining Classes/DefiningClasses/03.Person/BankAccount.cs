using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return this.id; }
        set
        {
            id = value;
        }
    }

    public decimal Balance
    {
        get { return this.balance; }
        set
        {
            balance = value;
        }
    }

    public void Deposit(decimal amount)
    {
        this.balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= balance)
            this.balance -= amount;
        else
            Console.WriteLine("Insufficient balance");

    }

    //override ToString() method
    public override string ToString()
    {
        return $"Account ID{Id}, balance { Balance.ToString("F2") }";
    }
}

