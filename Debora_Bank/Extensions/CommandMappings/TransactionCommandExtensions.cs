using Debora_Bank.Commands.Transaction;
using Debora_Bank.Dtos.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debora_Bank.Extensions.CommandMappings
{
    public static class TransactionCommandExtensions
    {
        public static InsertTransactionCommand MapToCommand(this TransactionPostRequest transaction, Guid id)
        {
            if (transaction is null) return null;

            return new InsertTransactionCommand(
                id, 
                transaction.TransactionType, 
                transaction.Date, 
                transaction.Value, 
                transaction.BalanceBefore, 
                transaction.BalanceAfter, 
                transaction.Account);
        }

        public static UpdateTransactionCommand MapToCommand(this TransactionPutRequest transaction, Guid id)
        {
            if (transaction is null) return null;

            return new UpdateTransactionCommand(
                id,
                transaction.TransactionType,
                transaction.Date,
                transaction.Value,
                transaction.BalanceBefore,
                transaction.BalanceAfter,
                transaction.Account);
        }
    }
}
