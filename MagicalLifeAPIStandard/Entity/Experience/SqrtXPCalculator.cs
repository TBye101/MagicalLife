using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.Experience
{
    /// <summary>
    /// Calculates XP to the next level based on a sqrt function.
    /// </summary>
    [ProtoContract]
    public class SqrtXPCalculator : IXPCalculator
    {
        [ProtoMember(1)]
        private int Constant;

        /// <param name="constant">A constant to scale the results by.</param>
        public SqrtXPCalculator(int constant)
        {
            this.Constant = constant;
        }

        public ulong GetRequiredXP(ulong newLevel)
        {
            return (ulong)(this.Constant * (int)Math.Sqrt(newLevel));
        }
    }
}
