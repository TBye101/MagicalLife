using EarthMagicDocumentation;
using System;
using System.Collections.Generic;

namespace EarthWithMagicAPI.API.Creature
{
    public abstract class IAbility
    {
        /// <summary>
        /// Area of Effect Spell?
        /// </summary>
        public bool AOESpell;

        public int AvailibleUses;

        /// <summary>
        /// The unique id for this spell instance.
        /// </summary>
        public Guid ID = new Guid();

        /// <summary>
        /// Lore about the spell.
        /// </summary>
        public List<string> Info;

        public int MaxUses;

        /// <summary>
        /// The name of the spell.
        /// </summary>
        public string Name;

        public int RoundsLeft;

        /// <summary>
        /// The xp value that this ability adds to the creature which has this.
        /// </summary>
        public int XPValue = 0;

        private string ImagePath;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="DocumentationPath"></param>
        /// <param name="Uses">The amount of uses this ability can be used right after resting.</param>
        /// <param name="AOE">Area of effect spell?</param>
        protected IAbility(string name, string DocumentationPath, bool AOE, int Uses, int roundsLeft, string imagePath)
        {
            this.Name = name;
            this.AOESpell = AOE;
            this.Info = ResourceGM.GetResource(DocumentationPath);
            this.MaxUses = Uses;
            this.RoundsLeft = roundsLeft;
            this.ImagePath = imagePath;
        }

        /// <summary>
        /// Displays this ability's image.
        /// </summary>
        public void DisplayImage()
        {
            Util.Util.WriteLine(ResourceGM.GetResource(this.ImagePath));
        }

        public abstract void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster);

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

        /// <summary>
        /// Called when the creature's affect wears off.
        /// </summary>
        public abstract void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected);

        /// <summary>
        /// Resets the uses count.
        /// </summary>
        public void Rest()
        {
            this.AvailibleUses = this.MaxUses;
        }
    }
}