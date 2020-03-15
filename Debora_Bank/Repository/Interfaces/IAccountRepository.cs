using Debora_Bank.Entities;
using System;
using System.Collections.Generic;

namespace Debora_Bank.Repository.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        Account GeAccount(int transactionId);
        Account GetAccount(int accountId);
        void InsertAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
