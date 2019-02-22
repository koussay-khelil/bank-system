using System;
using System.Collections.Generic;
using System.Linq;
using Bank.Transaction;
using Serilog;


namespace Bank.TheAccounts
{

    public abstract class AbstractAccount<TClientKey, TTransactionEntity, TAccountKey, TTransactionKey> : IAccounts<TAccountKey, TTransactionEntity,
            TTransactionKey>
        where TTransactionEntity : Transactions<TTransactionKey, TAccountKey>, new()
    {
        public Decimal Balance { get; set; }
        public  TClientKey Owner { get; set; }
        public List<TTransactionEntity> TransactionList { get; set; }
        public TAccountKey AccountKey { get; set; }
        public double TaxRatio { get; set; }
        
        public DateTime Date { get; set; }
       
        public States State { get; set; }

        public AbstractAccount(TClientKey owner, TAccountKey accountKey)
        {
            Balance = 0;
            Owner = owner;
            TransactionList = new List<TTransactionEntity>();
            AccountKey = accountKey;
           Date = DateTime.Now;
            State = States.Active;

        }

       
      

        public IEnumerable<TTransactionEntity> GetAllTransactions()
        {
            return TransactionList;
        }

        public IEnumerable<TTransactionEntity> GetTransactionsByDate(DateTime date)
        {
            return from _transaction in TransactionList where _transaction.Date.Equals(date) select _transaction;
        }

        public IEnumerable<TTransactionEntity> GetTransactionsByTarget(TAccountKey targetAccountNumber)
        {
            return from _transaction in TransactionList
                where _transaction.Target.Equals(targetAccountNumber)
                select _transaction;
        }

        public IEnumerable<TTransactionEntity> GetTransactionsByQuery(Func<TTransactionEntity, bool> query)
        {
            return TransactionList.Where(query);
        }

        public void Debit(decimal amount, TTransactionEntity transaction)
        {
            Balance -=  amount;
            SendMoney(transaction);
        }
        public virtual void DebitAccount (decimal amount, TTransactionKey transactionKey, TAccountKey accountKey)
        { }

        public virtual void CreditAccount(decimal amount, TTransactionKey transactionNumber, TAccountKey sourceTransactionKey)
        {
            Balance += amount;
            Transactions<TTransactionKey, TAccountKey> transaction = new Transactions<TTransactionKey,TAccountKey>(transactionNumber, sourceTransactionKey, AccountKey,amount,Direction.incoming,Transaction.State.Accepted);
            SendMoney((TTransactionEntity)transaction);
        }

        public void LoggingTRansactions(TTransactionEntity transaction)
        {
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }
        public void SendMoney(TTransactionEntity transaction)
        {
            TransactionList.Add(transaction);
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

       
    }
}

