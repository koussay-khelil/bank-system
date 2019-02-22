using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Bank.Transaction;
using Bank.TheAccounts;

namespace Bank.Client
{
    public abstract class AbstractClient<TAccountEntity, TAccountKey> : IClient<TAccountEntity, TAccountKey>

    {
        public string CIN { get; set; }
        public string Name { get; set; }
        public List<TAccountEntity> Accounts { get; set; }

        public AbstractClient(string name , string cin)
        {
            Name = name;
            CIN = cin;
            Accounts = new List<TAccountEntity>();
        }

        public abstract IEnumerable<TAccountEntity> GetAllAccounts();


        public abstract TAccountEntity GetAccount(TAccountKey account);


        public abstract void CreateAccount(TAccountEntity account);

        public abstract void CloseAccount(TAccountEntity account);

    }
}
