using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    [Serializable]
    public class ResourceMissingException : Exception
    {
        public ResourceMissingException() : base("A resource was not found in its expected location!")
        {
        }

        public ResourceMissingException(string msg) : base(msg)
        {
        }

        public ResourceMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}