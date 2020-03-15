﻿using System;

namespace Debora_Bank.Exceptions
{
    public class CommandValidationException<T> : Exception where T : Enum
    {
        public T Error { get; }

        public CommandValidationException(T error)
            : base(error.ToString())
        {
            Error = error;
        }
    }
}
