using Debora_Bank.Commands.Transaction;
using Debora_Bank.Dtos.Transaction;

namespace Debora_Bank.Extensions.CommandMappings
{
    public static class TransactionCommandExtensions
    {
        public static InsertTransactionCommand MapToCommand(this TransactionPostRequest transaction)
        {
            if (transaction is null) return null;

            return new InsertTransactionCommand( 
                transaction.TransactionType, 
                transaction.Date, 
                transaction.Value, 
                transaction.AccountId);
        }

        public static UpdateTransactionCommand MapToCommand(this TransactionPutRequest transaction, int id)
        {
            if (transaction is null) return null;

            return new UpdateTransactionCommand(
                id,
                transaction.TransactionType,
                transaction.Date,
                transaction.Value,
                transaction.AccountId);
        }
    }
}
