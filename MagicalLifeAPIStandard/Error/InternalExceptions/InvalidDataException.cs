using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    /// <summary>
    /// Thrown when some circumstance causes data to be invalid/unusable.
    /// </summary>
    [Serializable]
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg)
        {
        }

        public InvalidDataException() : base("Some circumstance caused data to be invalid/unusable")
        {
        }

        public InvalidDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}