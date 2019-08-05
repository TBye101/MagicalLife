using System;
using System.Runtime.Serialization;

namespace MLAPI.Error.InternalExceptions
{
    [Serializable]
    public class InvalidTextureException : Exception
    {
        public InvalidTextureException() : base("A texture is invalid")
        {
        }

        public InvalidTextureException(string msg) : base(msg)
        {
        }

        public InvalidTextureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTextureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}