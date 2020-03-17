using Debora_Bank.Domain.Commands.Account;
using Debora_Bank.Dtos.Account;

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
