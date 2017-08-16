using EarthWithMagicAPI.API.Util;
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
        /// <summary>
        /// The IDs of the angels we added.
        /// </summary>
        private List<Guid> Angels = new List<Guid>();

        public SummonHolySection(int uses) : base("Summon Holy Section", "EarthMagicDocumentation.Abilities.Summon Holy Section.md", false, uses, 8)
        {
        }

        public override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            LesserAngel a = new LesserAngel();
            LesserAngel b = new LesserAngel();
            LesserAngel c = new LesserAngel();
            LesserAngel d = new LesserAngel();

            Angels.Add(a.ID);
            Angels.Add(b.ID);
            Angels.Add(c.ID);
            Angels.Add(d.ID);

            Party.Add(a);
            Party.Add(b);
            Party.Add(c);
            Party.Add(d);
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return true;
        }

        public override bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            this.RoundsLeft--;
            return true;
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            foreach (Guid item in this.Angels)
            {
                int length = Party.Count;
                for (int i = 0; i < length; i++)
                {
                    if (Party[i].ID == item)
                    {
                        Party.RemoveAt(i);
                        i--;
                        length--;
                    }
                }
            }

            this.Angels.Clear();

            Util.WriteLine("Lesser Angels despawning!");
        }
    }
}
