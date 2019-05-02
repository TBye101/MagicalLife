using System;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    [Serializable]
    public class RegistryDeletionException : Exception
    {
        public RegistryDeletionException() : base("A failure occurred while trying a deletion operation in a registry.")
        {
        }

        public RegistryDeletionException(string msg) : base(msg)
        {
        }

        public RegistryDeletionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegistryDeletionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}