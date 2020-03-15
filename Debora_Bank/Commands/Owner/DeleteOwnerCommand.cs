using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;

namespace Debora_Bank.Commands.Owner
{
    public class DeleteOwnerCommand
    {
        public Guid Id { get; set; }

        public DeleteOwnerCommand(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            if(Id == null)
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidId);
        }
    }
}
