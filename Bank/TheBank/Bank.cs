using System;
using Bank.Clients;
using System.Collections.Generic;
using System.Linq;
using Bank.Client;
using Bank.TheAccounts;
using Bank.Transaction;
using Serilog;


namespace Bank.TheBank
{

    public class Bank<TBankKey, TClient, TTransactionEntity, TTransactionKey, TAccountKey, TAccountEntity> :
        AbstractBank<TBankKey, TClient, TTransactionEntity, TTransactionKey, TAccountKey, TAccountEntity>

        where TClient : IClient<TAccountEntity, TAccountKey>
        where TAccountEntity : IAccounts<TAccountKey, TTransactionEntity, TTransactionKey>
        where TTransactionEntity : Transactions<TTransactionKey, TAccountKey>


    {
        public Bank(string bankName, TBankKey swiftCode) : base(bankName, swiftCode)
        {
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

        public override void AddTransaction(TTransactionEntity transaction)
        {
            if (Agents > 0)
            {
                Agents--;
                lock (TransactionsQueue)
                {
                    TransactionsQueue.Enqueue(transaction);
                    TAccountEntity sender = ClientList.Select(_account => _account.GetAccount(transaction.Source))
                        .FirstOrDefault();
                    TAccountEntity reciever = ClientList.Select(_account => _account.GetAccount(transaction.Target))
                        .FirstOrDefault();
                    try
                    {
                        
                        
                            sender.DebitAccount(transaction.Amount, transaction.TransactionNumber, transaction.Target);
                            reciever.CreditAccount(transaction.Amount, transaction.TransactionNumber, transaction.Source);
                        
                       
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("something fucked up" +" "+ e.Message);
                    }

                    TransactionsQueue.Dequeue();

                }

                Agents++;
            }

            Console.WriteLine("Get some Agents first you cheap fucker");
        }

        public override void AddAgent()
        {
            Agents++;
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

        public override void AddAgents(int numberOfAgents)
        {
            Agents += numberOfAgents;
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

        public override void RemoveAgent()
        {
            Agents--;
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }

        public override void RemoveAgents(int numberOfAgents)
        {
            Agents -= numberOfAgents;
            var logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Koussay Khelil\.dotnet").CreateLogger();
        }
    }
}
