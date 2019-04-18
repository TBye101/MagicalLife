using System;
using System.Collections;
using System.Runtime.Serialization;

namespace MagicalLifeAPI.Error.InternalExceptions
{
   [Serializable]
    public class CollectionEmptyException : Exception
    {
        public CollectionEmptyException() : base("Collection empty!")
        {
        }

        public CollectionEmptyException(string msg) : base(msg)
        {
        }

        public CollectionEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CollectionEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}