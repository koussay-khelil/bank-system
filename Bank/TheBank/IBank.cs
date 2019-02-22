using System;
using System.Collections.Generic;
using System.Text;
using Bank.Client;
using Bank.Clients;
using Bank.TheAccounts;

namespace Bank
{
    public interface IBank<TBankKey, TClient, TTransactionEntity, TTransactionKey, TAccountKey, TAccountEntity>
        where TClient : IClient<TAccountEntity, TAccountKey>
        where TAccountEntity : IAccounts<TAccountKey, TTransactionEntity, TTransactionKey>
        where TTransactionEntity : Transactions<TTransactionKey, TAccountKey>


    {
        
        void AddTransaction(TTransactionEntity transaction);
       // TAbstractAccount Account(TAccountKey accountKey);
        void AddAgent();
        void AddAgents(int numberOfAgents);
        void RemoveAgent();
        void RemoveAgents(int numberOfAgents);

        List<TClient> ClientList { get; set; }




    }
}
