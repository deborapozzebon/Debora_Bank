using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;

namespace Debora_Bank.Commands.Transaction
{
    public class DeleteTransactionCommand
    {
        public int Id { get; set; }

        public DeleteTransactionCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidId);
        }
    }
}
