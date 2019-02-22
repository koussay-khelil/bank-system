using System;
using Bank.TheAccounts;
using Bank.Client;
using Bank.Clients;
using Bank.TheBank;

namespace Bank
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>> client =
                new Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>>("Koussay",
                    14302722);
             SavingsAccount<int, Transactions<int, int>, int, int> Savings = new SavingsAccount<int, Transactions<int, int>, int, int>(client.CIN, 12345);
             client.CreateAccount(Savings);

             foreach (var a in client.GetAllAccounts())
             {
                 Console.WriteLine(a.AccountKey.ToString() + " " + a.State);
             }


            Console.WriteLine(client.GetAccount(12345));
            Console.WriteLine(client.Name);
            Console.WriteLine(client.GetAllAccounts());

            Console.WriteLine("Hello World!");
            

            Console.ReadLine();
        }
    }

   
}
