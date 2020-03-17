using Debora_Bank.Domain.Context;
using Debora_Bank.Domain.Entities;
using Debora_Bank.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debora_Bank.Domain.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DeboraBankDbContext _dbContext;

        public TransactionRepository(DeboraBankDbContext dbContext)
        {
            if (dbContext is null)
                throw new ArgumentNullException(nameof(dbContext));

            _dbContext = dbContext;
        }
        public Transaction GetTransaction(int transactionId)
        {
            if (transactionId == null)
                throw new ArgumentNullException(nameof(transactionId));

            return _dbContext.Transactions.FirstOrDefault(p => p.Id.Equals(transactionId));
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _dbContext.Transactions.AsEnumerable();
        }

        public IEnumerable<Transaction> GetTransactions(int accountId)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            return _dbContext.Transactions.Where(p => p.AccountId.Equals(accountId));
        }

        public void InsertTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            _dbContext.Transactions.Update(transaction);
            _dbContext.SaveChanges();
        }

        public void DeleteTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            _dbContext.Transactions.Remove(transaction);
            _dbContext.SaveChanges();
        }
    }
}
