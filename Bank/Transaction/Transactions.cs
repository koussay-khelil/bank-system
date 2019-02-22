using System;
using System.Collections.Generic;
using System.Text;
using Bank.Client;
using Bank.Transaction;


namespace Bank
{
    public class Transactions<TTransactionkey, TAccountKey>
    {
       

        
        public TTransactionkey TransactionNumber { get; set; }
        public TAccountKey Source { get; set; }
        public TAccountKey Target { get; set; }
        public decimal Amount { get; set; }
        public Direction Direction { get; set; }
        public State State { get; set; }
        public DateTime Date { get; set; }
        public Transactions() { }

        public Transactions(TTransactionkey transactionNumber, TAccountKey source, TAccountKey target, Decimal amount,
            Direction direction, State state)
        {
            TransactionNumber = transactionNumber;
            Source = source;
            Target = target;
            Amount = amount;
            Direction = direction;
            Date = DateTime.Now;
            State = state;
        }
       
       


    }
}
