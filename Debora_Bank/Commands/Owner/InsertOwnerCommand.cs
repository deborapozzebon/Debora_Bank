using Debora_Bank.Entities;
using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debora_Bank.Commands.Owner
{
    public class InsertOwnerCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public Account Account { get; set; }

        public InsertOwnerCommand(
            Guid id,
            string name,
            string CPF,
            Account account)
        {
            this.Id = id;
            this.Name = name;
            this.CPF = CPF;
            this.Account = account;
        }

        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidId);

            if (string.IsNullOrEmpty(Name))
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidName);

            if (string.IsNullOrEmpty(CPF))
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidCPF);

            if (Account == null)
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidAccount);
        }
    }
}
