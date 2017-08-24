// <copyright file="MonkAI.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCharacters.Classes.Monk
{
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// The AI for a monk.
    /// </summary>
    public class MonkAI : IAI
    {
        public void YourTurn(Encounter encounter, ICreature creature)
        {
            creature.BareHands.Attack(encounter.Party[0]);
        }
    }
}