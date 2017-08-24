// <copyright file="FireBolt.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicMagic.Spells.Wizard
{
    using System.Collections.Generic;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Util;

    public class Fire_Bolt : ISpell
    {
        public Fire_Bolt()
            : base("Firebolt", "EarthMagicDocumentation.Spells.Wizard.Firebolt.md", 9, 0, "EarthMagicDocumentation.ASCII_Art.Spells.Wizard.Firebolt.txt", true)
        {
        }

        public override bool OnAction(List<ICreature> party, List<ICreature> enemies, ICreature Affected)
        {
            return true;
        }

        public override bool OnTurn(List<ICreature> party, List<ICreature> enemies, ICreature affected)
        {
            return true;
        }

        /// <summary>
        /// Called when it is peace.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="affected"></param>
        /// <returns></returns>
        public override bool OnTurn(List<ICreature> party, ICreature affected)
        {
            return true;
        }

        public override void OnWearOff(List<ICreature> party, List<ICreature> enemies, ICreature affected)
        {
        }

        protected override bool Go(List<ICreature> party, List<ICreature> enemies, ICreature caster)
        {
            Damage damage = new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 10, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero());

            int missiles = 4;

            while (missiles != 0)
            {
                missiles--;

                if (caster.IsHostile())
                {
                    party[0].RecieveDamage(damage);
                }
                else
                {
                    enemies[0].RecieveDamage(damage);
                }
            }

            return true;
        }

        protected override bool Go(List<ICreature> theParty, ICreature creature)
        {
            return false;
        }
    }
}