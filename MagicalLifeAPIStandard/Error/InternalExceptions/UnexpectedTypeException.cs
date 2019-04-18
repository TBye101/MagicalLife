using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    /// <summary>
    /// For use when a type was not expected.
    /// </summary>
    [Serializable]
    public class UnexpectedTypeException : Exception
    {
        public UnexpectedTypeException() : base("A type was unexpected in the current context")
        {
        }

        public UnexpectedTypeException(string message) : base(message)
        {
        }

        public UnexpectedTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnexpectedTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}