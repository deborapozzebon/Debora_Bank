using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Debora_Bank.Dtos.Account
{
    public class AccountGetResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("currentBalance")]
        public double CurrentBalance { get; set; }

        [JsonProperty("historic")]
        public ICollection<Entities.Transaction> Historic { get; set; }
    }
}
