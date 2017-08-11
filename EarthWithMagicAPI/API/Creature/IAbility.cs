using EarthMagicDocumentation;
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
        public List<string> Info;

        /// <summary>
        /// The unique id for this spell instance.
        /// </summary>
        public Guid ID = new Guid();

        /// <summary>
        /// Area of Effect Spell?
        /// </summary>
        public bool AOESpell;

        public int MaxUses;
        public int AvailibleUses;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="DocumentationPath"></param>
        /// <param name="Uses">The amount of uses this ability can be used right after resting.</param>
        /// <param name="AOE">Area of effect spell?</param>
        public IAbility(string name, string DocumentationPath, bool AOE, int Uses)
        {
            this.Name = name;
            this.AOESpell = AOE;
            Info = ResourceGM.GetResource(DocumentationPath);
            this.MaxUses = Uses;
        }

        public abstract void Go(List<ICreature> Party, List<ICreature> Enemies);
    }
}
