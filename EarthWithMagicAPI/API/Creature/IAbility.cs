using EarthMagicDocumentation;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Creature
{
    public abstract class IAbility
    {
        public int RoundsLeft;

        /// <summary>
        /// The xp value that this ability adds to the creature which has this.
        /// </summary>
        public int XPValue = 0;

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
        protected IAbility(string name, string DocumentationPath, bool AOE, int Uses, int roundsLeft)
        {
            this.Name = name;
            this.AOESpell = AOE;
            this.Info = ResourceGM.GetResource(DocumentationPath);
            this.MaxUses = Uses;
            this.RoundsLeft = roundsLeft;
        }

        /// <summary>
        /// Resets the uses count.
        /// </summary>
        public void Rest()
        {
            this.AvailibleUses = this.MaxUses;
        }

        public abstract void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster);

        /// <summary>
        /// Called when the creature's affect wears off.
        /// </summary>
        public abstract void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected);

        /// <summary>
        /// Called whenever the creature tries to take an action.
        /// Returns whether or not the creature is allowed to take an action.
        /// </summary>
        public abstract bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected);

        /// <summary>
        /// Does stuff if it wants to on the creature's turn. Returns if the creature gets to do anything, or if it just has to end it's turn.
        /// </summary>
        /// <param name="Party"></param>
        /// <param name="Enemies"></param>
        /// <param name="Affected"></param>
        /// <returns></returns>
        public abstract bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected);
    }
}