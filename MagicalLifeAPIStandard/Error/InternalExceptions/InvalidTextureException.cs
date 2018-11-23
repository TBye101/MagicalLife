using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    public class InvalidTextureException : Exception
    {
        public InvalidTextureException() : base("A texture is invalid")
        {
        }

        public InvalidTextureException(string msg) : base(msg)
        {
        }
    }
}
