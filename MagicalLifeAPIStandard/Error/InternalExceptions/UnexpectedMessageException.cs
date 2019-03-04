using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    /// <summary>
    /// Thrown whenever a message was not handled due to its type.
    /// </summary>
    internal class UnexpectedMessageException : Exception
    {
        public UnexpectedMessageException(string msg) : base(msg)
        {
        }

        public UnexpectedMessageException() : base("A message was not handled due to its type being unexpected!")
        {
        }
    }
}