using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
