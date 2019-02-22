using System;
using System.Collections.Generic;
using System.Text;
using Bank.TheAccounts;



namespace Bank.TheAccounts
{
    public interface IAccounts <TAccountKey, TTransactionEntity, TTransactionKey>
    {
        TAccountKey AccountKey { get; set; }
        States State { get; set; }
        IEnumerable<TTransactionEntity> GetAllTransactions();
        IEnumerable<TTransactionEntity> GetTransactionsByDate(DateTime date);
        IEnumerable<TTransactionEntity> GetTransactionsByTarget(TAccountKey targetAccountNumber);
        IEnumerable<TTransactionEntity> GetTransactionsByQuery(Func<TTransactionEntity, bool> query);
        void DebitAccount(decimal amount, TTransactionKey transactionKey, TAccountKey accountKey);
        void Debit(decimal amount, TTransactionEntity transaction);
        void CreditAccount(decimal amount,  TTransactionKey transactionNumber, TAccountKey sourceTransactionKey);
        void SendMoney(TTransactionEntity transaction);
       

    }
}
