using Newtonsoft.Json;
using System.Collections.Generic;

namespace Debora_Bank.Dtos.Account
{
    public class AccountPostRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("currentBalance")]
        public double CurrentBalance { get; set; }

        [JsonProperty("historic")]
        public ICollection<Domain.Entities.Transaction> Historic { get; set; }
    }
}
