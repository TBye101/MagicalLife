using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.InternalExceptions
{
    public class UnexpectedEnumMemberException : Exception
    {
        public UnexpectedEnumMemberException() : base("A new member was added to an enum and was unaccounted")
        {
        }

        public UnexpectedEnumMemberException(string msg) : base(msg)
        {
        }
    }
}
