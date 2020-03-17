using Debora_Bank.Domain.Exceptions;
using Debora_Bank.Domain.Exceptions.Error;

namespace Debora_Bank.Domain.Commands.Account
{
    public class DeleteAccountCommand
    {
        public int Id { get; set; }

        public DeleteAccountCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidId);
        }
    }
}
