using Debora_Bank.Context;
using Debora_Bank.Entities;
using Debora_Bank.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debora_Bank.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DeboraBankDbContext _dbContext;

        public Owner GetOwner(Guid ownerId)
        {
            if (ownerId == null)
                throw new ArgumentNullException(nameof(ownerId));

            return _dbContext.Owners.FirstOrDefault(p => p.Id.Equals(ownerId));
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _dbContext.Owners.AsEnumerable();
        }

        public IEnumerable<Owner> GetOwners(Guid accountId)
        {
            if (accountId == null)
                throw new ArgumentNullException(nameof(accountId));

            return _dbContext.Owners.Where(p => p.Account.Id.Equals(accountId));
        }

        public void InsertOwner(Owner owner)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _dbContext.Owners.Add(owner);
            _dbContext.SaveChanges();
        }

        public void UpdateOwner(Owner owner)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _dbContext.Owners.Add(owner);
            _dbContext.SaveChanges();
        }

        public void DeleteOwner(Owner owner)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            _dbContext.Owners.Add(owner);
            _dbContext.SaveChanges();
        }

    }
}
