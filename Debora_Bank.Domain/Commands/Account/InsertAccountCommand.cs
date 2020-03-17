using Debora_Bank.Domain.Exceptions;
using Debora_Bank.Domain.Exceptions.Error;
using System.Collections.Generic;

namespace Debora_Bank.Domain.Commands.Account
{
    public class InsertAccountCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public double CurrentBalance { get; set; }
        public ICollection<Entities.Transaction> Historic { get; set; }

        public InsertAccountCommand(
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
