using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    /// <summary>
    /// Thrown whenever a message was not handled due to its type.
    /// </summary>
    [Serializable]
    public class UnexpectedMessageException : Exception
    {
        public UnexpectedMessageException(string msg) : base(msg)
        {
        }

        public UnexpectedMessageException() : base("A message was not handled due to its type being unexpected!")
        {
        }

        public UnexpectedMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnexpectedMessageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}