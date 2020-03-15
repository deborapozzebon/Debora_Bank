using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using Debora_Bank.Repository.Interfaces;
using System;

namespace Debora_Bank.Commands.Transaction
{
    public class TransactionCommandHandler
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionCommandHandler(
            ITransactionRepository transactionRepository)
        {
            if (transactionRepository is null)
                throw new ArgumentNullException(nameof(transactionRepository));

            _transactionRepository = transactionRepository;
        }

        public Entities.Transaction Handle(InsertTransactionCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var transaction = new Entities.Transaction
            {
                TransactionType = command.TransactionType,
                Value = command.Value,
                BalanceBefore = command.BalanceBefore,
                BalanceAfter = command.BalanceAfter,
                Date = command.Date,
                Account = command.Account
            };

            _transactionRepository.InsertTransaction(transaction);

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

            transaction.TransactionType = command.TransactionType;
            transaction.Value = command.Value;
            transaction.Date = command.Date;
            transaction.BalanceBefore = command.BalanceBefore;
            transaction.BalanceAfter = command.BalanceAfter;
            transaction.Account = command.Account;

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
    }
}
