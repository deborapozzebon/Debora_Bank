using Debora_Bank.Entities;
using Newtonsoft.Json;
using System;

namespace Debora_Bank.Dtos.Owner
{
    public class OwnerPostRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("account")]
        public Entities.Account Account { get; set; }
    }
}
