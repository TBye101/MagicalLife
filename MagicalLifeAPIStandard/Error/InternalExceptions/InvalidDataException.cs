using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    /// <summary>
    /// Thrown when some circumstance causes data to be invalid/unusable.
    /// </summary>
    internal class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg)
        {
        }

        public InvalidDataException() : base("Some circumstance caused data to be invalid/unusable")
        {
        }
    }
}