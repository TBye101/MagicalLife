using System;
using ProtoBuf;

namespace MLAPI.Entity.Experience
{
    /// <summary>
    /// Classes that implement this have custom algorithms for how to calculate the XP required to get to the next level.
    /// </summary>
    [ProtoContract]
    public interface IXpCalculator
    {
        /// <summary>
        /// Returns the amount of XP required to get to the next level.
        /// </summary>
        /// <param name="previousLevel">The level that the creature just completed.</param>
        /// <returns></returns>
        UInt64 GetRequiredXp(int newLevel);
    }
}