using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    public class RegistryDeletionException : Exception
    {
        public RegistryDeletionException() : base("A failure occurred while trying a deletion operation in a registry.")
        {
        }

        public RegistryDeletionException(string msg) : base(msg)
        {
        }
    }
}
