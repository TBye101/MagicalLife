using System;

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