﻿using Debora_Bank.Entities;
using Debora_Bank.Entities.Enums;
using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debora_Bank.Commands.Transaction
{
    public class UpdateTransactionCommand
    {
        public Guid Id { get; set; }
        public eTransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double BalanceBefore { get; set; }
        public double BalanceAfter { get; set; }
        public Account Account { get; set; }

        public UpdateTransactionCommand(
            Guid id,
            eTransactionType transactionType,
            DateTime date,
            double value,
            double balanceBefore,
            double balanceAfter,
            Account account)
        {
            Id = id;
            TransactionType = transactionType;
            Date = date;
            Value = value;
            BalanceBefore = balanceBefore;
            BalanceAfter = balanceAfter;
            Account = account;
        }

        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidId);

            if (TransactionType == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidTransactionType);

            if (Date == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidDate);

            if (Double.IsNaN(Value))
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidVale);

            if (Double.IsNaN(BalanceBefore))
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidBalanceBefore);

            if (Double.IsNaN(BalanceAfter))
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidBalanceAfter);

            if (Account == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidAccount);
        }
    }
}
