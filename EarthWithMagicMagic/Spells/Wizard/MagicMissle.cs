// <copyright file="MagicMissle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicMagic.Spells.Wizard
{
    using System;
    using System.Collections.Generic;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Util;

    public class MagicMissle : ISpell
    {
        public MagicMissle()
            : base("Magic Missile", "EarthMagicDocumentation.Spells.Wizard.Magic_Missile.md", 3, 0, "EarthMagicDocumentation.ASCII_Art.Spells.Wizard.Magic_Missile.txt", true)
        {
        }

        protected override bool Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            Util.WriteLine(Caster.Name + " is casting Magic Missile!");
            Damage damage = new Damage(Die.Zero(), Die.Zero(), Die.Zero(),
                Die.Zero(), Die.Zero(), new Die(1, 6, 2),
                Die.Zero(), Die.Zero(), Die.Zero());
            int missiles = Caster.Attributes.XP.CreatureLevel / 4;

            if (missiles < 1)
            {
                missiles = 1;
            }

            while (missiles != 0)
            {
                missiles--;
                if (Caster.IsHostile())
                {
                    Party[0].RecieveDamage(damage);
                }
                else
                {
                    Enemies[0].RecieveDamage(damage);
                }
            }

            return true;
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return true;
        }

        public override bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return true;
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
        }

        protected override bool Go(List<ICreature> theParty, ICreature creature)
        {
            return false;
        }

        public override bool OnTurn(List<ICreature> Party, ICreature Affected)
        {
            return true;
        }
    }
}