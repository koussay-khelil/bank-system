using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Bank.TheAccounts;
using Bank.Client;
using Bank.Transaction;

namespace Bank.TheAccounts
{
    class BusinessAccount<TClientKey, TTransactionEntity, TAccountKey, TTransactionKey> : AbstractAccount<TClientKey, TTransactionEntity, TAccountKey, TTransactionKey> where TTransactionEntity : Transactions<TTransactionKey, TAccountKey>, new()
    {
       
        public BusinessAccount(TClientKey owner, TAccountKey accountKey) : base(owner, accountKey)
        {
            TaxRatio = 0.01;
        }

        public override void DebitAccount(decimal amount, TTransactionKey transactionKey, TAccountKey accountKey)
        {
            decimal Result = ((decimal) (TaxRatio * (double) amount)) + amount;
           Transactions<TTransactionKey, TAccountKey> transaction = new Transactions<TTransactionKey, TAccountKey>(transactionKey, accountKey, AccountKey, amount, Direction.incoming, Transaction.State.Accepted);
            

            
            if (Balance >= Result)
            {
                transaction.State = Transaction.State.Accepted;
                Debit(Result, (TTransactionEntity)transaction);
            }
           
            else
            {
                transaction.State = Transaction.State.Rejected;
                throw new Exception("no no no no can't do that");
            }
        }

        public override void CreditAccount(decimal amount, TTransactionKey transactionNumber, TAccountKey sourceTransactionKey)
        {
            if (State == States.Closed)
            {
                throw new  Exception("no can't do bruh");
            }
            base.CreditAccount(amount, transactionNumber, sourceTransactionKey);
        }

        
    }
}
