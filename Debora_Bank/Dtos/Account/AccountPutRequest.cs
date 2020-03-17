﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Debora_Bank.Dtos.Account
{
    public class AccountPutRequest
    {
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
