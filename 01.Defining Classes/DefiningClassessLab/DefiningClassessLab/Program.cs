namespace DefiningClassessLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {

            List<BankAccount> accounts = new List<BankAccount>();
            
            while (true)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                var command = input[0];

                if (command == "End")
                    break;

                int[] commandArgs = input.Skip(1)
                    .Select(int.Parse)
                    .ToArray();
                
                int id = commandArgs[0];
                int amount = 0;

                switch (command)
                {
                    case "Create":
                        TestClient.Create(id, accounts);
                        break;

                    case "Deposit":
                        amount = commandArgs[1];
                        TestClient.Deposit(id, amount, accounts);
                        break;

                    case "Withdraw":
                        amount = commandArgs[1];
                        TestClient.Withdraw(id, amount, accounts);
                        break;

                    case "Print":
                        TestClient.Print(id, accounts);
                        break;
                }

            }

        }
        
    }
}










