using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    [Serializable]
    public class InvalidPathException : Exception
    {
        public InvalidPathException() : base("A destination is not possible")
        {
        }

        public InvalidPathException(string msg) : base(msg)
        {
        }

        public InvalidPathException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPathException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}