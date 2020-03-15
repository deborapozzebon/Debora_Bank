using Debora_Bank.Commands.Owner;
using Debora_Bank.Dtos.Owner;
using System;

namespace Debora_Bank.Extensions.CommandMappings
{
    public static class OwnerCommandExtensions
    {
        public static InsertOwnerCommand MapToCommand(this OwnerPostRequest owner, int id)
        {
            if (owner is null) return null;

            return new InsertOwnerCommand(id, owner.Name, owner.CPF, owner.AccountId, owner.Account);
        }

        public static UpdateOwnerCommand MapToCommand(this OwnerPutResquest owner, int id)
        {
            if (owner is null) return null;
            
            return new UpdateOwnerCommand(id, owner.Name, owner.CPF, owner.AccountId, owner.Account);
        }
    }
}
