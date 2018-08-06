using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    /// <summary>
    /// Thrown when some circumstance causes data to be invalid/unusable.
    /// </summary>
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg)
        {
        }

        public InvalidDataException() : base("Some circumstance caused data to be invalid/unusable")
        {

        }
    }
}
