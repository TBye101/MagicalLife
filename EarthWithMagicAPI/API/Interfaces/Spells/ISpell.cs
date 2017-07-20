using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
namespace EarthWithMagicAPI.API.Interfaces.Spells
{
    /// <summary>
    /// The base class for spells.
    /// </summary>
    public abstract class ISpell
    {
        /// <summary>
        /// The name of the spell.
        /// </summary>
        public string Name;

        /// <summary>
        /// Lore about the spell.
        /// </summary>
        public List<string> Lore;

        /// <summary>
        /// Any other information about the spell.
        /// </summary>
        public List<string> OtherInformation;

        /// <summary>
        /// The unique id for this spell instance.
        /// </summary>
        public Guid ID = new Guid();

        /// <summary>
        /// The amount of power this spell consumes when cast.
        /// </summary>
        public int PowerRequired;

        /// <summary>
        /// Area of Effect Spell?
        /// </summary>
        public bool AOESpell;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lore"></param>
        /// <param name="otherInformation"></param>
        /// <param name="powerRequired"></param>
        /// <param name="AOE">Area of effect spell?</param>
        public ISpell(string name, List<string> lore, List<string> otherInformation, int powerRequired, bool AOE)
        {
            this.Name = name;
            this.Lore = lore;
            this.OtherInformation = otherInformation;
            this.PowerRequired = powerRequired;
            this.AOESpell = AOE;
        }

        /// <summary>
        /// Called when the spell is cast on a creature.
        /// </summary>
        /// <param name="creature"></param>
        public abstract void ApplyToCreature(ICreature creature);

        /// <summary>
        /// Applies the spell to every creature on the list that qualifies as an enemy.
        /// </summary>
        /// <param name="creatures"></param>
        /// <param name="toFriendlies">Used to determine who to target. If false, it applies the spell to all of the player's enemies.</param>
        public static void ApplySpellTo(List<ICreature> creatures, bool toFriendlies, ISpell spell)
        {
            foreach (ICreature item in creatures)
            {
                if (toFriendlies)
                {
                    if (!item.IsHostile())
                    {
                        spell.ApplyToCreature(item);
                    }
                }
                else
                {
                    if (item.IsHostile())
                    {
                        spell.ApplyToCreature(item);
                    }
                }
            }
        }
    }
}