using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;

namespace Debora_Bank.Commands.Owner
{
    public class UpdateOwnerCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int AccountId { get; set; }
        public Entities.Account Account { get; set; }

        public UpdateOwnerCommand(
            int id,
            string name, 
            string CPF,
            int accountId,
            Entities.Account account)
        {
            this.Id = id;
            this.Name = name;
            this.CPF = CPF;
            this.AccountId = accountId;
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
