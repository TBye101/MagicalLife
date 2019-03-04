using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    internal class DuplicateEntryException : Exception
    {
        public DuplicateEntryException() : base("A duplicate entry was detected")
        {
        }

        public DuplicateEntryException(string msg) : base(msg)
        {
        }
    }
}