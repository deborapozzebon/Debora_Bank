using Debora_Bank.Commands.Account;
using Debora_Bank.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debora_Bank.Extensions.CommandMappings
{
    public static class AccountCommandExtensions
    {
        public static InsertAccountCommand MapToCommand(this AccountPostRequest account)
        {
            if (account is null) return null;

            return new InsertAccountCommand(0, account.Name, account.CPF, account.CurrentBalance, account.Historic);
        }

        public static UpdateAccountCommand MapToCommand(this AccountPutRequest account, int id)
        {
            if (account is null) return null;

            return new UpdateAccountCommand(id, account.Name, account.CPF, account.CurrentBalance, account.Historic);
        }
    }
}
