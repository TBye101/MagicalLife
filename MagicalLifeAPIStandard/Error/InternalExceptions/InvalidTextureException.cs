using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    public class InvalidTextureException : Exception
    {
        public InvalidTextureException() : base("A texture is invalid")
        {
        }

        public InvalidTextureException(string msg) : base(msg)
        {
        }
    }
}