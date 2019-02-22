using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Bank.Client;
using Bank.TheAccounts;

namespace Bank.TheBank
{
    public abstract class AbstractBank<TBankKey, TClient, TTransactionEntity, TTransactionKey, TAccountKey, TAccountEntity> : IBank<TBankKey, TClient, TTransactionEntity, TTransactionKey, TAccountKey, TAccountEntity>
        where TClient : IClient<TAccountEntity, TAccountKey>
        where TAccountEntity : IAccounts<TAccountKey, TTransactionEntity, TTransactionKey>
        where TTransactionEntity : Transactions<TTransactionKey, TAccountKey>
    {
        public string BankName { get; set; }
        public List<TClient> ClientList { get; set; }
        public  List<TTransactionEntity> TransactionList { get; set; }
        public TBankKey SwiftCode { get; set; }
        public int Agents { get; set; }
        public Queue TransactionsQueue { get; set; }
        public Lazy<IEnumerable<TAccountEntity>> TheAccounts;
        public Lazy<IEnumerable<TTransactionEntity>> TheTransactions;

        public AbstractBank(string bankName, TBankKey swiftCode)
        {
            BankName = bankName;
            SwiftCode = swiftCode;
           TransactionList = new List<TTransactionEntity>();
            TransactionsQueue = new Queue();
            ClientList = new List<TClient>();
            TheAccounts = new Lazy<IEnumerable<TAccountEntity>>();
            TheTransactions = new Lazy<IEnumerable<TTransactionEntity>>();
        }

        public IEnumerable<TTransactionEntity> GetAllTransactions()
        {
            foreach (var client in ClientList)
            {
                foreach (var account in client.GetAllAccounts())
                {
                    foreach (var transaction in account.GetAllTransactions())
                    {
                        yield return transaction;
                    }
                }
            }
        }

        public IEnumerable<TAccountEntity> GetAllAccountEntities()
        {
            foreach (var client in ClientList)
            {
                foreach (var account in client.GetAllAccounts())
                {
                    yield return account;
                }
            }
        }


        public abstract void AddTransaction(TTransactionEntity transaction);
       

        public abstract void AddAgent();
       

        public abstract void AddAgents(int numberOfAgents);
        

        public abstract void RemoveAgent();
        

        public abstract void RemoveAgents(int numberOfAgents);
        
    }
}
