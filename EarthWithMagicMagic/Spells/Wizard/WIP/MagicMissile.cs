using EarthWithMagicAPI.API.Util;
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
            Damage damage = new Damage(EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(),
                EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(), new EarthWithMagicAPI.API.Util.Die(1, 6, 2),
                EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero(), EarthWithMagicAPI.API.Util.Die.Zero());
            if (Caster.IsHostile())
            {
                Party[0].RecieveDamage(damage);
            }
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            throw new NotImplementedException();
        }

        public override bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            throw new NotImplementedException();
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            throw new NotImplementedException();
        }
    }
}
