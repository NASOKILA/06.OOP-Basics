using System;
public class BankAccount
{
    //private poleta
    private int id;
    private double balance;

    //public propertita
    public int ID
    {
        get { return this.id; }

        set
        {
            this.id = value;
        }

    }

    public double Balance
    {
        get { return this.balance; }
        set
        {
            this.balance = value;
        }
    }

    public void Deposit(double amount)
    {
        this.balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (this.balance - amount > 0)
            this.balance -= amount;
        else
            throw new ArgumentException("Not enougn money !");
        
    }

    public override string ToString()
    {
        return $"Account { this.ID }, balance {this.Balance}";
    }

}

