using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException() : base("A duplicate entry was detected")
        {
        }

        public DuplicateEntryException(string msg) : base(msg)
        {
        }
    }
}
