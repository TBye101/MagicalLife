using EarthMagicCreatures.Creatures.Heavenly.Angels;
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
        public SummonHolySection() : base("Summon Holy Section", "EarthMagicDocumentation.Abilities.Summon Holy Section.md", false)
        {
        }

        public override void ApplyToCreature(ICreature creature, List<ICreature> Party, List<ICreature> Enemies)
        {
            Party.Add(new LesserAngel());
            Party.Add(new LesserAngel());
            Party.Add(new LesserAngel());
            Party.Add(new LesserAngel());
        }
    }
}
