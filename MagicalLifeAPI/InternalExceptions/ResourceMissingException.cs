using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    public class ResourceMissingException : Exception
    {
        public ResourceMissingException() : base("A resource was not found in its expected location!")
        {
        }

        public ResourceMissingException(string msg) : base(msg)
        {
        }
    }
}
