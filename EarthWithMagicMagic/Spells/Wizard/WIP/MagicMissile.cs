﻿using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API;
using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API.Creature;

namespace EarthWithMagicMagic.Spells.Wizard
{
    public class MagicMissle : ISpell
    {
        public MagicMissle() : base("Magic Missile", "EarthMagicDocumentation.Spells.Wizard.Magic_Missile.md", 3, false, 0)
        {
        }

        public override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            Util.WriteLine(Caster.Name + " is casting Magic Missile!");
            Damage damage = new Damage(EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(),
                EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(), new EarthWithMagicAPI.API.Util.Die(1, 6, 2),
                EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero());
            int Missiles = Caster.Attributes.XP.CreatureLevel / 4;

            if (Missiles < 1)
            {
                Missiles = 1;
            }

            while (Missiles != 0)
            {
                Missiles--;
                if (Caster.IsHostile())
                {
                    Party[0].RecieveDamage(damage);
                }
                else
                {
                    Enemies[0].RecieveDamage(damage);
                }
            }
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
    }
}
