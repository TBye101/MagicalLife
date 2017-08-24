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
        public StunningBlow() : base("Stunning Blow", "EarthMagicDocumentation.Abilities.Monk.StunningBlow.md", false, 1, 2, "EarthMagicDocumentation.ASCII_Art.Abilities.StunningBlow.txt")
        {
        }

        protected override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            string N;
            if (Caster.IsHostile())
            {
                Party[0].AbilitiesAffectedBy.Add(this);
                N = Party[0].Name;
            }
            else
            {
                Enemies[0].AbilitiesAffectedBy.Add(this);
                N = Party[0].Name;
            }

            Util.WriteLine(Caster.Name + " uses Stunning Blow on " + N);
        }

        protected override void Go(List<ICreature> Party, ICreature Caster)
        {
            this.AvailibleUses++;
            Util.WriteLine("This ability is not available when not in battle!");
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return false;
        }

        public override bool OnTurn(List<ICreature> Party, ICreature Affected)
        {
            Util.WriteLine(Affected.Name + " is affected by a stunning blow and cannot move!");
            this.RoundsLeft--;
            return false;
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            Util.WriteLine(Affected.Name + " is no longer affected by stunning blow");
        }
    }
}