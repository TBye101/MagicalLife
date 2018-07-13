using System;

namespace MagicalLifeAPI.InternalExceptions
{
    public class InvalidPathException : Exception
    {
        public InvalidPathException() : base("A destination is not possible")
        {
        }

        public InvalidPathException(string msg) : base(msg)
        {
        }
    }
}