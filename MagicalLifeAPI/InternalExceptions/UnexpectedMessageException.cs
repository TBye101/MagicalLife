using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    /// <summary>
    /// Thrown whenever a message was not handled due to its type.
    /// </summary>
    public class UnexpectedMessageException : Exception
    {
        public UnexpectedMessageException(string msg) : base(msg)
        {

        }

        public UnexpectedMessageException() : base("A message was not handled due to its type being unexpected!")
        {
        }
    }
}
