using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    public class UnexpectedStateException : Exception
    {
        public UnexpectedStateException() : base("The state of an object has not been expected")
        {
        }

        public UnexpectedStateException(string msg) : base(msg)
        {
        }
    }
}