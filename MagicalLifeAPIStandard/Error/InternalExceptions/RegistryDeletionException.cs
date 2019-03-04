using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    internal class RegistryDeletionException : Exception
    {
        public RegistryDeletionException() : base("A failure occurred while trying a deletion operation in a registry.")
        {
        }

        public RegistryDeletionException(string msg) : base(msg)
        {
        }
    }
}