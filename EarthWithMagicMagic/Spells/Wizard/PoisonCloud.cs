﻿using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API.Creature;

namespace EarthWithMagicMagic.Spells.Wizard
{
    public class PoisonCloud : ISpell
    {
        public PoisonCloud() : base("Poison Cloud", "EarthMagicDocumentation.Spells.Wizard.PoisonCloud.md", 21, 4, "EarthMagicDocumentation.ASCII_Art.Spells.Wizard.PoisonCloud.txt")
        {
        }

        public override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
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

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
        }
    }
}