﻿using Debora_Bank.Entities;
using Debora_Bank.Entities.Enums;
using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;

namespace Debora_Bank.Commands.Transaction
{
    public class InsertTransactionCommand
    {
        public int Id { get; set; }
        public eTransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public int AccountId { get; set; }

        public InsertTransactionCommand(
            eTransactionType transactionType,
            DateTime date,
            double value,
            int accountId)
        {
            TransactionType = transactionType;
            Date = date;
            Value = value;
            AccountId = accountId;
        }

        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidId);

            if (Date == null)
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidDate);

            if (Double.IsNaN(Value))
                throw new CommandValidationException<eTransactionsError>(eTransactionsError.InvalidVale);
        }
    }
}
