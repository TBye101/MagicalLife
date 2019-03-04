using System;

namespace MagicalLifeAPI.Error.InternalExceptions
{
    internal class UnexpectedEnumMemberException : Exception
    {
        public UnexpectedEnumMemberException() : base("A new member was added to an enum and was unaccounted")
        {
        }

        public UnexpectedEnumMemberException(string msg) : base(msg)
        {
        }
    }
}