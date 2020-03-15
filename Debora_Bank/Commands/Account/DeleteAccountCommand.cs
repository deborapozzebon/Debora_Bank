﻿using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using System;

namespace Debora_Bank.Commands.Account
{
    public class DeleteAccountCommand
    {
        public int Id { get; set; }

        public DeleteAccountCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            if (Id == null)
                throw new CommandValidationException<eAccountError>(eAccountError.InvalidId);
        }
    }
}
