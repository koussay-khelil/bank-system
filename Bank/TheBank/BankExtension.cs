using System;
using System.Collections.Generic;
using System.Text;
using Bank.Clients;
using Bank.TheAccounts;
using Serilog;
using System.Linq;

namespace Bank.TheBank
{
    public class BankExtension
    {
        public void AddClient(
            this Bank<int, Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>>,
                Transactions<int, int>, int, int, IAccounts<int, Transactions<int, int>, int>> bank,
            Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>> client)
        {
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

        //public Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>> GetClient(
        //    this Bank<int, Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>>,
        //        Transactions<int, int>, int, int, IAccounts<int, Transactions<int, int>, int>> bank, int cin)
        //{
        //    Client<int, int, IAccounts<int, Transactions<int, int>, int>, Transactions<int, int>> client = (from _client in bank.ClientList where _client.Equals() select _client)).FirstOrDefault();
        //}


    }
}
