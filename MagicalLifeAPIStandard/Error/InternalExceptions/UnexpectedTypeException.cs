using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    /// <summary>
    /// For use when a type was not expected.
    /// </summary>
    internal class UnexpectedTypeException : Exception
    {
        public UnexpectedTypeException() : base("A type was unexpected in the current context")
        {
        }

        public UnexpectedTypeException(string message) : base(message)
        {
        }
    }
}