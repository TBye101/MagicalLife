using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicMagic.Abilities.Monk
{
    /// <summary>
    /// Summons 4 lesser angels.
    /// </summary>
    public class SummonHolySection : IAbility
    {
        public SummonHolySection(List<string> lore, List<string> otherInformation) : base("Summon Holy Section", lore, otherInformation, false)
        {
        }

        public override void ApplyToCreature(ICreature creature)
        {
            throw new NotImplementedException();
        }
    }
}
