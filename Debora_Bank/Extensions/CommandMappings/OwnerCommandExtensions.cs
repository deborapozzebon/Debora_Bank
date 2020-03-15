using Debora_Bank.Commands.Owner;
using Debora_Bank.Dtos;
using System;

namespace Debora_Bank.Extensions.CommandMappings
{
    public static class OwnerCommandExtensions
    {
        public static InsertOwnerCommand MapToCommand(this OwnerPostRequest owner, Guid id)
        {
            if (owner is null) return null;

            return new InsertOwnerCommand(id, owner.Name, owner.CPF, owner.Account);
        }

        public static UpdateOwnerCommand MapToCommand(this OwnerPutResquest owner, Guid id)
        {
            if (owner is null) return null;
            
            return new UpdateOwnerCommand(id, owner.Name, owner.CPF, owner.Account);
        }
    }
}
