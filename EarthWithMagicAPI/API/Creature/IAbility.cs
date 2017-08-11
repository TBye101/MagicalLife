using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    public abstract class IAbility
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
        public IAbility(string name, List<string> lore, List<string> otherInformation, bool AOE)
        {
            this.Name = name;
            this.Lore = lore;
            this.OtherInformation = otherInformation;
            this.AOESpell = AOE;
        }

        /// <summary>
        /// Called when the spell is cast on a creature.
        /// </summary>
        /// <param name="creature"></param>
        public abstract void ApplyToCreature(ICreature creature, List<ICreature> Party, List<ICreature> Enemies);

        /// <summary>
        /// Applies the spell to every creature on the list that qualifies as an enemy.
        /// </summary>
        /// <param name="creatures"></param>
        /// <param name="toFriendlies">Used to determine who to target. If false, it applies the spell to all of the player's enemies.</param>
        public void ApplySpellTo(List<ICreature> Enemies, List<ICreature> Party, bool toFriendlies, IAbility ability)
        {
            if (toFriendlies)
            {
                foreach (ICreature item in Party)
                {
                    this.ApplyToCreature(item, Party, Enemies);
                }
            }
            else
            {
                foreach (ICreature item in Enemies)
                {
                    this.ApplyToCreature(item, Party, Enemies);
                }
            }
        }
    }
}
