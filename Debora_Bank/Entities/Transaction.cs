using System;
using Debora_Bank.Entities.Enums;

namespace Debora_Bank.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public eTransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
