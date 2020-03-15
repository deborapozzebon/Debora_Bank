using Debora_Bank.Entities;
using Debora_Bank.Entities.Enums;
using Newtonsoft.Json;
using System;

namespace Debora_Bank.Dtos.Transaction
{
    public class TransactionPostRequest
    {
        [JsonProperty("transactionType")]
        public eTransactionType TransactionType { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("balanceBefore")]
        public double BalanceBefore { get; set; }

        [JsonProperty("balanceAfter")]
        public double BalanceAfter { get; set; }

        [JsonProperty("account")]
        public Entities.Account Account { get; set; }
    }
}
