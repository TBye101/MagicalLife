// <copyright file="IAbility.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Creature
{
    using System;
    using System.Collections.Generic;
    using EarthMagicDocumentation;

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
        /// <param name="aOE">Area of effect spell?</param>
        protected IAbility(string name, string documentationPath, bool aOE, int uses, int roundsLeft, string imagePath)
        {
            this.Name = name;
            this.AOESpell = aOE;
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

        /// <summary>
        /// For use during a battle.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="caster"></param>
        /// <returns>Returns whether we successfully activated the ability.</returns>
        public bool Use(List<ICreature> party, List<ICreature> enemies, ICreature caster)
        {
            if (this.AvailibleUses > 0)
            {
                this.Go(party, enemies, caster);
                return true;
            }
            else
            {
                Util.Util.WriteLine(caster.Name + " failed to activate " + this.Name + " because there were no ability uses left.");
                return false;
            }
        }

        /// <summary>
        /// For use during peaceful times.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="caster"></param>
        /// <returns>Returns whether we successfully activated the ability.</returns>
        public bool Use(List<ICreature> party, ICreature caster)
        {
            if (this.AvailibleUses > 0)
            {
                this.Go(party, caster);
                return true;
            }
            else
            {
                Util.Util.WriteLine(caster.Name + " failed to activate " + this.Name + " because there were no ability uses left.");
                return false;
            }
        }

        /// <summary>
        /// Actually activates the ability.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="caster"></param>
        protected abstract void Go(List<ICreature> party, List<ICreature> enemies, ICreature caster);

        /// <summary>
        /// Actually activates the ability.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="caster"></param>
        protected abstract void Go(List<ICreature> party, ICreature caster);

        /// <summary>
        /// Called whenever the creature tries to take an action.
        /// Returns whether or not the creature is allowed to take an action.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="affected"></param>
        /// <returns></returns>
        public abstract bool OnAction(List<ICreature> party, List<ICreature> enemies, ICreature affected);

        /// <summary>
        /// Does stuff if it wants to on the creature's turn. Returns if the creature gets to do anything, or if it just has to end it's turn.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="Enemies"></param>
        /// <param name="affected"></param>
        /// <returns></returns>
        public abstract bool OnTurn(List<ICreature> party, ICreature affected);

        /// <summary>
        /// Called when the creature's affect wears off.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="affected"></param>
        public abstract void OnWearOff(List<ICreature> party, List<ICreature> enemies, ICreature affected);

        /// <summary>
        /// Resets the uses count.
        /// </summary>
        public void Rest()
        {
            this.AvailibleUses = this.MaxUses;
        }
    }
}