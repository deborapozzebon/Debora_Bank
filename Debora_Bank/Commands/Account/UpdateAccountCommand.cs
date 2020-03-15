using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debora_Bank.Commands.Account
{
    public class UpdateAccountCommand
    {
        public Guid Id { get; set; }
        public Entities.Owner Owner { get; set; }
        public double CurrentBalance { get; set; }
        public ICollection<Entities.Transaction> Historic { get; set; }

        public UpdateAccountCommand(
            Guid id,
            Entities.Owner owner,
            double currentBalance,
            ICollection<Entities.Transaction> historic)
        {
            Id = id;
            Owner = owner;
            CurrentBalance = currentBalance;
            Historic = historic;
        }
        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidId);

            if (Owner is null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidOwner);

            if (double.IsNaN(CurrentBalance))
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidCurrentBalance);

            if (Historic is null || !Historic.Any())
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidHistoric);
        }
    }
}
