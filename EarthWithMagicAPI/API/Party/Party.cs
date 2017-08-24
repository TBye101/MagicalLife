// <copyright file="Party.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Party
{
    using EarthWithMagicAPI.API.Creature;
    using System.Collections.Generic;

    /// <summary>
    /// The party that the main character is traveling with. This includes the main character.
    /// </summary>
    public static class Party
    {
        public static List<ICreature> TheParty = new List<ICreature>();
    }
}