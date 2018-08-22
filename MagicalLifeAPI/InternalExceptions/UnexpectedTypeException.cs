using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    class UnexpectedTypeException : Exception
    {
        public UnexpectedTypeException() : base("A type was unexpected in the current context")
        {
        }

        public UnexpectedTypeException(string message) : base(message)
        {
        }
    }
}
