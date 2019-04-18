using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    [Serializable]
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException() : base("A duplicate entry was detected")
        {
        }

        public DuplicateEntryException(string msg) : base(msg)
        {
        }

        public DuplicateEntryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateEntryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}