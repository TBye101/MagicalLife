﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.Experience
{
    /// <summary>
    /// Classes that implement this have custom algorithms for how to calculate the XP required to get to the next level.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(SqrtXPCalculator))]
    public interface IXPCalculator
    {
        /// <summary>
        /// Returns the amount of XP required to get to the next level.
        /// </summary>
        /// <param name="previousLevel">The level that the creature just completed.</param>
        /// <returns></returns>
        UInt64 GetRequiredXP(UInt64 newLevel);
    }
}