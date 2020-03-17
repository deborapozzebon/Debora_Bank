using Debora_Bank.Domain.Context;
using Debora_Bank.Domain.Entities;
using Debora_Bank.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debora_Bank.Domain.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DeboraBankDbContext _dbContext;

        public AccountRepository(DeboraBankDbContext dbContext)
        {
            if (dbContext is null)
                throw new ArgumentNullException(nameof(dbContext));

            _dbContext = dbContext;
        }

        public Account GetAccount(int accountId)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            return _dbContext.Accounts.FirstOrDefault(p => p.Id.Equals(accountId));
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _dbContext.Accounts.AsEnumerable();
        }

        public Account GeAccount(int transactionId)
        {
            return new Account();
            //TODO RETORNAR O ACCOUNT CORRETO
            //if (transactionId == null)
            //    throw new ArgumentNullException(nameof(transactionId));

            //return _dbContext.Transactions.FirstOrDefault(p => p.Id.Equals(transactionId));
        }
        
        public void InsertAccount(Account account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }

        public void DeleteAccount(Account account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();
        }
    }
}
