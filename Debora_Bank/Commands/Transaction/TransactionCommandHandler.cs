using Debora_Bank.Entities.Enums;
using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using Debora_Bank.Repository.Interfaces;
using System;

namespace Debora_Bank.Commands.Transaction
{
    public class TransactionCommandHandler
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionCommandHandler(
            ITransactionRepository transactionRepository)
        {
            if (transactionRepository is null)
                throw new ArgumentNullException(nameof(transactionRepository));

            _transactionRepository = transactionRepository;
        }

        public TransactionCommandHandler(
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository)
        {
            if (transactionRepository is null)
                throw new ArgumentNullException(nameof(transactionRepository));

            if (accountRepository is null)
                throw new ArgumentNullException(nameof(transactionRepository));

            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public Entities.Transaction Handle(InsertTransactionCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var account = _accountRepository.GetAccount(command.AccountId);

            UpdateValues(command.TransactionType, command.Value, account);

            var transaction = new Entities.Transaction
            {
                TransactionType = command.TransactionType,
                Value = command.Value,
                Date = command.Date,
                AccountId = command.AccountId
            };

            _transactionRepository.InsertTransaction(transaction);
            _accountRepository.UpdateAccount(account);

            return transaction;
        }

        public Entities.Transaction Handle(UpdateTransactionCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var transaction = _transactionRepository.GetTransaction(command.Id);
            if (transaction is null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidId);

            var account = _accountRepository.GetAccount(transaction.AccountId);

            RevertValues(transaction.TransactionType, transaction.Value, account);
            UpdateValues(command.TransactionType, command.Value, account);

            transaction.TransactionType = command.TransactionType;
            transaction.Value = command.Value;
            transaction.Date = command.Date;
            transaction.AccountId = account.Id;

            _accountRepository.UpdateAccount(account);
            _transactionRepository.UpdateTransaction(transaction);

            return transaction;
        }

        public void Handle(DeleteTransactionCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var owner = _transactionRepository.GetTransaction(command.Id);

            if (owner == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidId);

            _transactionRepository.DeleteTransaction(owner);
        }

        private static void UpdateValues(eTransactionType transactionType, double value, Entities.Account account)
        {
            switch (transactionType)
            {
                case eTransactionType.Deposit:
                    account.CurrentBalance += value;
                    break;
                case eTransactionType.Payment:
                case eTransactionType.Withdraw:
                default:
                    account.CurrentBalance -= value;
                    break;
            }
        }

        private static void RevertValues(eTransactionType transactionType, double value, Entities.Account account)
        {
            switch (transactionType)
            {
                case eTransactionType.Deposit:
                    account.CurrentBalance -= value;
                    break;
                case eTransactionType.Payment:
                case eTransactionType.Withdraw:
                default:
                    account.CurrentBalance += value;
                    break;
            }
        }
    }
}
