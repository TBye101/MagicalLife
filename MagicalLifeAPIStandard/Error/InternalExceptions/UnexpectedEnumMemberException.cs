using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    [Serializable]
    public class UnexpectedEnumMemberException : Exception
    {
        public UnexpectedEnumMemberException() : base("A new member was added to an enum and was unaccounted")
        {
        }

        public UnexpectedEnumMemberException(string msg) : base(msg)
        {
        }

        public UnexpectedEnumMemberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnexpectedEnumMemberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}