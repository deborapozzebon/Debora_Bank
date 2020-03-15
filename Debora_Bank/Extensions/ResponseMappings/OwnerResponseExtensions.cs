using Debora_Bank.Dtos.Owner;
using Debora_Bank.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Debora_Bank.Extensions.ResponseMappings
{
    public static class OwnerResponseExtensions
    {
        public static OwnerGetResponse MapToResponse(this Owner owner)
        {
            if (owner is null)
                return null;

            return new OwnerGetResponse
            {
                Id = owner.Id,
                Name = owner.Name,
                CPF = owner.CPF,
                Account = owner.Account
            };
        }

        public static List<OwnerGetResponse> MapToResponse(this IEnumerable<Owner> owners)
        {
            if (owners is null || !owners.Any())
                return null;

            var result = new List<OwnerGetResponse>();

            foreach (var owner in owners)
                result.Add(owner.MapToResponse());

            return result;
        }
    }
}
