// <copyright file="ICreatureGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagic.CreatureGen
{
    using EarthWithMagicAPI.API.Creature;

    /// <summary>
    /// Generates a monk character by asking the user questions.
    /// </summary>
    public interface ICreatureGenerator
    {
        /// <summary>
        /// Returns the created creature.
        /// </summary>
        /// <returns></returns>
        ICreature Generate();
    }
}