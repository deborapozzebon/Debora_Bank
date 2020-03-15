using Debora_Bank.Entities;
using System.Collections.Generic;
using System;

namespace Debora_Bank.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> GetTransactions(Guid accountId);
        Transaction GetTransaction(Guid transactionId);
        void InsertTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(Transaction transaction);
    }
}
