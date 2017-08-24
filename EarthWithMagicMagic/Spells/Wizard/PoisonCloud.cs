// <copyright file="PoisonCloud.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicMagic.Spells.Wizard
{
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Util;
    using System;
    using System.Collections.Generic;

    public class PoisonCloud : ISpell
    {
        public PoisonCloud()
            : base("Poison Cloud", "EarthMagicDocumentation.Spells.Wizard.PoisonCloud.md", 21, 4, "EarthMagicDocumentation.ASCII_Art.Spells.Wizard.PoisonCloud.txt", true)
        {
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return true;
        }

        public override bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            this.RoundsLeft--;
            Affected.RecieveDamage(new EarthWithMagicAPI.API.Damage(Die.Zero(), new Die(1, 8, 2), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero()));
            return true;
        }

        public override bool OnTurn(List<ICreature> Party, ICreature Affected)
        {
            throw new NotImplementedException();
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
        }

        protected override bool Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            if (Caster.IsHostile())
            {
                foreach (ICreature item in Party)
                {
                    item.SpellsAffectedBy.Add(new PoisonCloud());
                }
            }
            else
            {
                foreach (ICreature item in Enemies)
                {
                    item.SpellsAffectedBy.Add(new PoisonCloud());
                }
            }
            return true;
        }

        protected override bool Go(List<ICreature> theParty, ICreature creature)
        {
            throw new NotImplementedException();
        }
    }
}