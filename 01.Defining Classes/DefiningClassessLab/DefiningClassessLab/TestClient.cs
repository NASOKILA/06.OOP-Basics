
using System;
using System.Collections.Generic;
using System.Linq;

public class TestClient
{
    
    public static void Print(int id, List<BankAccount> accounts)
    {
        if (accounts.Any(a => a.ID == id))
        {
            BankAccount acc = accounts.SingleOrDefault(a => a.ID == id);

            Console.WriteLine($"Account ID{acc.ID}, balance {acc.Balance:f2}");
        }
        else
            Console.WriteLine($"Account does not exist");
    }

    public static void Withdraw(int id, int amount, List<BankAccount> accounts)
    {

        if (accounts.Any(a => a.ID == id))
        {
            BankAccount acc = accounts.SingleOrDefault(a => a.ID == id);

            if (acc.Balance - amount < 0)
                Console.WriteLine("Insufficient balance");
            else
                acc.Balance -= amount;
        }
        else
            Console.WriteLine($"Account does not exist");
    }

    public static void Deposit(int id, int amount, List<BankAccount> accounts)
    {

        if (accounts.Any(a => a.ID == id))
        {
            BankAccount acc = accounts.SingleOrDefault(a => a.ID == id);
            acc.Balance += amount;
        }
        else
            Console.WriteLine($"Account does not exist");
    }

    public static void Create(int id, List<BankAccount> accounts)
    {
        //Ako ne se sudurja takuv akaunt
        if (!accounts.Any(a => a.ID == id))
        {
            BankAccount acc = new BankAccount();
            acc.ID = id;
            accounts.Add(acc);
        }
        else
            Console.WriteLine("Account already exists");

    }

}

