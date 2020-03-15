using Debora_Bank.Dtos.Transaction;
using Debora_Bank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debora_Bank.Extensions.ResponseMappings
{
    public static class TransactionResposeExtensions
    {
        public static TransactionGetResponse MapToResponse(this Transaction transaction)
        {
            if (transaction is null)
                return null;

            return new TransactionGetResponse
            {
                Id = transaction.Id,
                TransactionType = transaction.TransactionType,
                Date = transaction.Date,
                BalanceBefore = transaction.BalanceBefore,
                BalanceAfter = transaction.BalanceAfter,
                Value = transaction.Value,
                Account = transaction.Account
            };
        }

        public static List<TransactionGetResponse> MapToResponse(this IEnumerable<Transaction> transactions)
        {
            if (transactions is null || !transactions.Any())
                return null;

            var result = new List<TransactionGetResponse>();

            foreach (var transaction in transactions)
                result.Add(transaction.MapToResponse());

            return result;
        }
    }
}
