using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Debora_Bank.Dtos.Account
{
    public class AccountGetResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("owner")]
        public Entities.Owner Owner { get; set; }

        [JsonProperty("currentBalance")]
        public double CurrentBalance { get; set; }

        [JsonProperty("historic")]
        public ICollection<Entities.Transaction> Historic { get; set; }
    }
}
