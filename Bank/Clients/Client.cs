using System;
using System.Collections.Generic;
using System.Linq;
using Bank.Client;
using Bank.TheAccounts;
using Serilog;


namespace Bank.Clients

{
    public class Client<TTransactionKey, TAccountKey, TAccountEntity, TTransaction> : AbstractClient<TAccountEntity, TAccountKey>, IEquatable<int>
        where TAccountEntity : IAccounts<TAccountKey, TTransaction, TTransactionKey>

    {
        public Client(string name, string cin) : base(name, cin)
        {
        }

        public bool Equals(int OtherClient)
        {
            return CIN.Equals(OtherClient);
        }

        public override IEnumerable<TAccountEntity> GetAllAccounts()
        {
            return Accounts;
        }

        public override TAccountEntity GetAccount(TAccountKey _accountKey)
        {
           TAccountEntity account = (
                from a in Accounts
                where _accountKey.Equals(a.AccountKey)
                select a
            ).FirstOrDefault();

            return account;
        }

        public override void CreateAccount(TAccountEntity account)
        {
            Accounts.Add(account);
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

        public override void CloseAccount(TAccountEntity account)
        {
            TAccountEntity a = (from acc in Accounts where acc.AccountKey.Equals(account.AccountKey) select acc).FirstOrDefault();
            a.State = States.Closed;
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }
    }
   
};


   
