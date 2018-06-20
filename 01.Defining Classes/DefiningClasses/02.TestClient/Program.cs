using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        string[] command = Console.ReadLine()
       .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
       .ToArray();

        List<int> accountIds = new List<int>();

        List<BankAccount> bankAccounts = new List<BankAccount>();
        


        while (command[0] != "End")
        {

            int currentId = int.Parse(command[1]);

            if (command[0] == "Create")
            {

                if (!accountIds.Contains(currentId))
                {

                    BankAccount newAccount = new BankAccount();
                    newAccount.Id = currentId;
                    newAccount.Balance = 0;

                    bankAccounts.Add(newAccount);
                    accountIds.Add(currentId);
                }
                else
                    Console.WriteLine("Account already exists");

            }
            else if (command[0] == "Deposit")
            {
                decimal amount = decimal.Parse(command[2]);

                if (accountIds.Contains(currentId))
                {
                    BankAccount currentBankAccount = bankAccounts
                         .Where(bc => bc.Id == currentId)
                         .First();

                    currentBankAccount.Deposit(amount);

                }
                else
                    Console.WriteLine("Account does not exist");


            }
            else if (command[0] == "Withdraw")
            {
                decimal amount = decimal.Parse(command[2]);

                if (accountIds.Contains(currentId))
                {
                    BankAccount currentBankAccount = bankAccounts
                         .Where(bc => bc.Id == currentId)
                         .First();

                    currentBankAccount.Withdraw(amount);
                }
                else
                    Console.WriteLine("Account does not exist");

            }
            else if (command[0] == "Print")
            {
                if (accountIds.Contains(currentId))
                {
                    BankAccount currentAccount = bankAccounts
                        .Where(bc => bc.Id == currentId)
                        .First();

                    Console.WriteLine(currentAccount);
                }
                else
                    Console.WriteLine("Account does not exist");

            }


            command = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        }

    }
}

