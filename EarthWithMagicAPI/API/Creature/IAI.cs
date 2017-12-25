// <copyright file="IAI.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Creature
{
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// Used to abstract AI combat.
    /// </summary>
    public interface IAI
    {
        /// <summary>
        /// Your turn in combat.
        /// </summary>
        /// <param name="encounter">The current encounter.</param>
        /// <param name="creature">The monk this method must control.</param>
        void YourTurn(Encounter encounter, ICreature creature);

        /// <summary>
        /// A turn during a peaceful break.
        /// </summary>
        void YourTurn();
    }
}