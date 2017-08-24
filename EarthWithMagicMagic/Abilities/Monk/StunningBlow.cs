// <copyright file="StunningBlow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicMagic.Abilities.Monk
{
    using System;
    using System.Collections.Generic;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Stuns the target creature, if the hit is successful.
    /// Uses fists only for stunning blow.
    /// </summary>
    public class StunningBlow : IAbility
    {
        public StunningBlow()
            : base("Stunning Blow", "EarthMagicDocumentation.Abilities.Monk.StunningBlow.md", false, 1, 2, "EarthMagicDocumentation.ASCII_Art.Abilities.StunningBlow.txt")
        {
        }

        protected override void Go(List<ICreature> party, List<ICreature> enemies, ICreature caster)
        {
            string n;
            if (caster.IsHostile())
            {
                party[0].AbilitiesAffectedBy.Add(this);
                n = party[0].Name;
            }
            else
            {
                enemies[0].AbilitiesAffectedBy.Add(this);
                n = party[0].Name;
            }

            Util.WriteLine(caster.Name + " uses Stunning Blow on " + n);
        }

        protected override void Go(List<ICreature> party, ICreature caster)
        {
            this.AvailibleUses++;
            Util.WriteLine("This ability is not available when not in battle!");
        }

        public override bool OnAction(List<ICreature> party, List<ICreature> enemies, ICreature affected)
        {
            return false;
        }

        public override bool OnTurn(List<ICreature> party, ICreature affected)
        {
            Util.WriteLine(affected.Name + " is affected by a stunning blow and cannot move!");
            this.RoundsLeft--;
            return false;
        }

        public override void OnWearOff(List<ICreature> party, List<ICreature> enemies, ICreature affected)
        {
            Util.WriteLine(affected.Name + " is no longer affected by stunning blow");
        }
    }
}