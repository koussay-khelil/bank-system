using System;
using System.Collections.Generic;
using System.Text;


namespace Bank.Client
{
   public interface IClient<TAccountEntity, TAccountKey> 
    {
        IEnumerable<TAccountEntity> GetAllAccounts();




        TAccountEntity GetAccount(TAccountKey account);


        void CreateAccount(TAccountEntity account);

        void CloseAccount(TAccountEntity account);

       

    }
}
