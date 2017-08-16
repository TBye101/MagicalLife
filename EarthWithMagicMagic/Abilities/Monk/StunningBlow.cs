using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicMagic.Abilities.Monk
{
    /// <summary>
    /// Stuns the target creature, if the hit is successful.
    /// </summary>
    public class StunningBlow : IAbility
    {
        public StunningBlow() : base("Stunning Blow", "EarthMagicDocumentation.Abilities.Monk.StunningBlow.md", false, 1, 2)
        {
        }

        public override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return false;
        }

        public override bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return false;
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            
        }
    }
}
