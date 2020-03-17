using Debora_Bank.Domain.Entities.Enums;
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

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("account")]
        public Domain.Entities.Account Account { get; set; }
    }
}
