using System;
using ProtoBuf;

namespace MLAPI.Entity.Experience
{
    /// <summary>
    /// Calculates XP to the next level based on a sqrt function.
    /// </summary>
    [ProtoContract]
    public class SqrtXpCalculator : IXpCalculator
    {
        [ProtoMember(1)]
        private readonly int Constant;

        /// <summary>
        ///
        /// </summary>
        /// <param name="constant">A constant to scale the results by.</param>
        public SqrtXpCalculator(int constant)
        {
            this.Constant = constant;
        }

        protected SqrtXpCalculator()
        {
            //Protobuf-net constructor
        }

        public ulong GetRequiredXp(int newLevel)
        {
            return (ulong)(this.Constant * (int)Math.Sqrt(newLevel));
        }
    }
}