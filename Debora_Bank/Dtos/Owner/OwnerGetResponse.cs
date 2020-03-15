using Debora_Bank.Entities;
using Newtonsoft.Json;
using System;

namespace Debora_Bank.Dtos.Owner
{
    public class OwnerGetResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

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
