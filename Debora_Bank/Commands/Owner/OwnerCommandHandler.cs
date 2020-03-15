using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using Debora_Bank.Repository.Interfaces;
using System;

namespace Debora_Bank.Commands.Owner
{
    public class OwnerCommandHandler
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerCommandHandler(
            IOwnerRepository ownerRepository)
        {
            if (ownerRepository is null)
                throw new ArgumentNullException(nameof(ownerRepository));

            _ownerRepository = ownerRepository;
        }

        public Entities.Owner Handle(InsertOwnerCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var owner = new Entities.Owner
            {
                Name = command.Name,
                CPF = command.CPF,
                AccountId = command.AccountId,
                Account = command.Account
            };

            _ownerRepository.InsertOwner(owner);

            return owner;
        }

        public Entities.Owner Handle(UpdateOwnerCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var owner = _ownerRepository.GetOwner(command.Id);

            if(owner is null)
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidId);

            owner.Name = command.Name;
            owner.CPF = command.CPF;
            owner.AccountId = command.AccountId;
            owner.Account = command.Account;

            _ownerRepository.UpdateOwner(owner);

            return owner;
        }

        public void Handle(DeleteOwnerCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            command.Validate();

            var owner = _ownerRepository.GetOwner(command.Id);

            if (owner == null)
                throw new CommandValidationException<eOwnerError>(eOwnerError.InvalidId);

            _ownerRepository.DeleteOwner(owner);
        }
    }
}
