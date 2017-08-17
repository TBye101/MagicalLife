using EarthWithMagicAPI.API.Interfaces.Spells;
using System;
using System.Collections.Generic;
using System.Text;
using EarthWithMagicAPI.API.Creature;

namespace EarthWithMagicMagic.Spells.Wizard
{
    public class MagicMissle : ISpell
    {
        public MagicMissle() : base("Magic Missile", lore, otherInformation, powerRequired, AOE, maxUses, roundsLeft)
        {
        }

        public override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            throw new NotImplementedException();
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
