using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    internal class InvalidPathException : Exception
    {
        public InvalidPathException() : base("A destination is not possible")
        {
        }

        public InvalidPathException(string msg) : base(msg)
        {
        }
    }
}