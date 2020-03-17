using Debora_Bank.Entities;
using Debora_Bank.Entities.Enums;
using Newtonsoft.Json;
using System;

namespace Debora_Bank.Dtos.Transaction
{
    public class TransactionPutRequest
    {
        [JsonProperty("transactionType")]
        public eTransactionType TransactionType { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }
    }
}
