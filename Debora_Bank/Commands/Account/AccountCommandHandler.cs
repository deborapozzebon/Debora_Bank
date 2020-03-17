using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using Debora_Bank.Repository.Interfaces;
using System;

namespace Debora_Bank.Commands.Account
{
    public class AccountCommandHandler
    {
        private readonly IAccountRepository _accountRepository;

        public AccountCommandHandler(IAccountRepository accountRepository)
        {
            if (accountRepository is null)
                throw new ArgumentNullException(nameof(accountRepository));

            _accountRepository = accountRepository;
        }

        public Entities.Account Handle(InsertAccountCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var account = new Entities.Account
            {
                Name = command.Name,
                CPF = command.CPF,
                CurrentBalance = command.CurrentBalance,
                Historic = command.Historic
            };

            _accountRepository.InsertAccount(account);

            return account;
        }

        public Entities.Account Handle(UpdateAccountCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var account = _accountRepository.GetAccount(command.Id);

            if (account is null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidId);

            account.CurrentBalance = command.CurrentBalance;
            account.Historic = command.Historic;
            account.Name = command.Name;
            account.CPF = command.CPF;

            _accountRepository.UpdateAccount(account);

            return account;
        }

        public void Handle(DeleteAccountCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var account = _accountRepository.GetAccount(command.Id);

            if (account == null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidId);

            _accountRepository.DeleteAccount(account);
        }
    }
}
