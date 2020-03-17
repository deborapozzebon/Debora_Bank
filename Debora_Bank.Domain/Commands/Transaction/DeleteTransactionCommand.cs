using Debora_Bank.Domain.Exceptions;
using Debora_Bank.Domain.Exceptions.Error;

namespace Debora_Bank.Domain.Commands.Transaction
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
