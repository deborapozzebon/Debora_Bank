using Debora_Bank.Entities;
using System;
using System.Collections.Generic;

namespace Debora_Bank.Repository.Interfaces
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetOwners();
        IEnumerable<Owner> GetOwners(int accountId);
        Owner GetOwner(int ownerId);
        void InsertOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
