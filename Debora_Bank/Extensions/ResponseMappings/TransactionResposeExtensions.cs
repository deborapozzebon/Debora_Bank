using Debora_Bank.Domain.Entities;
using Debora_Bank.Dtos.Transaction;
using System.Collections.Generic;
using System.Linq;

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
                Value = transaction.Value,
                AccountId = transaction.AccountId
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
