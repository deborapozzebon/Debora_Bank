using System;

namespace Debora_Bank.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public Account Account { get; set; }
    }
}
