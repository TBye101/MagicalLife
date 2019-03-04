using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    internal class InvalidTextureException : Exception
    {
        public InvalidTextureException() : base("A texture is invalid")
        {
        }

        public InvalidTextureException(string msg) : base(msg)
        {
        }
    }
}