using Debora_Bank.Entities;
using Newtonsoft.Json;

namespace Debora_Bank.Dtos.Owner
{
    public class OwnerPutResquest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }
    }
}
