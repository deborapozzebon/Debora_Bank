using Debora_Bank.Dtos.Account;
using Debora_Bank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debora_Bank.Extensions.ResponseMappings
{
    public  static class AccountResponseExtensions
    {
        public static AccountGetResponse MapToResponse(this Account account)
        {
            if (account is null)
                return null;

            return new AccountGetResponse
            {
                Id = account.Id,
                CPF = account.CPF,
                Name = account.Name,
                CurrentBalance = account.CurrentBalance,
                Historic = account.Historic,
            };
        }

        public static List<AccountGetResponse> MapToResponse(this IEnumerable<Account> accounts)
        {
            if (accounts is null || !accounts.Any())
                return null;

            var result = new List<AccountGetResponse>();

            foreach (var account in accounts)
                result.Add(account.MapToResponse());

            return result;
        }
    }
}
