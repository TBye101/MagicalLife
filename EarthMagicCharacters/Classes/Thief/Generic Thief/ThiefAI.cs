// <copyright file="ThiefAI.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCharacters.Classes.Thief.Generic_Thief
{
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Stuff;

    public class ThiefAI : IAI
    {
        public void YourTurn(Encounter encounter, ICreature creature)
        {
            if (creature.Weapons.Count < 1)
            {
                creature.BareHands.Attack(encounter.Party[0]);
            }
            else
            {
                creature.Weapons[0].Attack(encounter.Party[0]);
            }
        }

        public void YourTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}