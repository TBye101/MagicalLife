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
        public SummonHolySection() : base("Summon Holy Section", new List<string> { "Long ago, the first monk in Faehau's service attended the annual Angelic Fighting Tournament.",
"The tournament was a event for angels to display their martial prowess.",
"The angels did not particularly respect the monk or his fighting abilities.",
"One angel in particular was trying to get into a fight with the monk, just so he could get an easy warm up fight.",
"The monk told that he would fight the angel, just to get it to leave him alone.",
"They went to the arena, where the angel declared that he was challenging the monk.",
"As the monk was challenged, he got to pick the weapons.",
"The monk chose unarmed and unarmored combat.",
" ",
"The angels laughed, for they believed that the monk would have no chance without weapons against an angel.",
"One minute later the angel was on the floor, his body shattered. The angel stared at the monk in disbelief.",
"The angel didn't think it possible for anyone to deal out the kind of damage the monk did with his fists.",
" ",
"Due to that incident, monks have become well respected fighters in Faehau's plane. Faehau granted the monk a small section (4 angels) of his army."
        }, new List<string> { "Summons 4 lesser angels." }, false)
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
