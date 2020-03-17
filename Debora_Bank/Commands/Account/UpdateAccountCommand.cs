using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debora_Bank.Commands.Account
{
    public class UpdateAccountCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public double CurrentBalance { get; set; }
        public ICollection<Entities.Transaction> Historic { get; set; }

        public UpdateAccountCommand(
            int id,
            string name,
            string cpf,
            double currentBalance,
            ICollection<Entities.Transaction> historic)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            CurrentBalance = currentBalance;
            Historic = historic;
        }
        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidId);

            if (double.IsNaN(CurrentBalance))
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidCurrentBalance);
        }
    }
}
