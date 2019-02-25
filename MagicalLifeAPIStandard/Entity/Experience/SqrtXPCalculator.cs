using ProtoBuf;
using System;

namespace MagicalLifeAPI.Entity.Experience
{
    /// <summary>
    /// Calculates XP to the next level based on a sqrt function.
    /// </summary>
    [ProtoContract]
    public class SqrtXPCalculator : IXPCalculator
    {
        [ProtoMember(1)]
        private readonly int Constant;

        /// <param name="constant">A constant to scale the results by.</param>
        public SqrtXPCalculator(int constant)
        {
            this.Constant = constant;
        }

        protected SqrtXPCalculator()
        {
            //Protobuf-net constructor
        }

        public ulong GetRequiredXP(int newLevel)
        {
            return (ulong)(this.Constant * (int)Math.Sqrt(newLevel));
        }
    }
}