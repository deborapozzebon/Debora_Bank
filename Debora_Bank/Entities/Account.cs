using System;
using System.Collections.Generic;

namespace Debora_Bank.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public Owner Owner { get; set; }
        public double CurrentBalance { get; set; }
        public ICollection<Transaction> Historic { get; set; }
    }
}
