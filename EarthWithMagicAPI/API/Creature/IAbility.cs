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

        /// <summary>
        /// The resource path to the documentation for this ability.
        /// </summary>
        private string DocumentationPath;

        /// <summary>
        /// The resource path to the image for this ability.
        /// </summary>
        private string ImagePath;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="documentationPath"></param>
        /// <param name="uses">The amount of uses this ability can be used right after resting.</param>
        /// <param name="roundsLeft"></param>
        /// <param name="imagePath"></param>
        /// <param name="AOE">Area of effect spell?</param>
        protected IAbility(string name, string documentationPath, bool AOE, int uses, int roundsLeft, string imagePath)
        {
            this.Name = name;
            this.AOESpell = AOE;
            this.MaxUses = uses;
            this.RoundsLeft = roundsLeft;
            this.ImagePath = imagePath;
            this.DocumentationPath = documentationPath;
        }

        /// <summary>
        /// Displays this ability's image.
        /// </summary>
        public void DisplayImage()
        {
            Util.Util.WriteLine(ResourceGM.GetResource(this.ImagePath));
        }

        public void DisplayDocumentation()
        {
            Util.Util.WriteLine(ResourceGM.GetResource(this.DocumentationPath));
        }

        public abstract void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster);

        /// <summary>
        /// Called whenever the creature tries to take an action.
        /// Returns whether or not the creature is allowed to take an action.
        /// </summary>
        /// <param name="Party"></param>
        /// <param name="Enemies"></param>
        /// <param name="Affected"></param>
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
        /// <param name="Party"></param>
        /// <param name="Enemies"></param>
        /// <param name="Affected"></param>
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