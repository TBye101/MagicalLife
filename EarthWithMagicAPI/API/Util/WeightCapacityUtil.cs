// <copyright file="WeightCapacityUtil.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Util
{
    using EarthWithMagicAPI.API.Creature;

    /// <summary>
    /// Used to calculate the carrying capacity of a creature.
    /// </summary>
    public static class WeightCapacityUtil
    {
        /// <summary>
        /// Determines how much weight a creature can carry.
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public static int Calculate(ICreature creature)
        {
            return creature.Attributes.Strength *= 20;
        }
    }
}