using Debora_Bank.Domain.Entities;
using System.Collections.Generic;

namespace Debora_Bank.Domain.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> GetTransactions(int accountId);
        Transaction GetTransaction(int transactionId);
        void InsertTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(Transaction transaction);
    }
}
