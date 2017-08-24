// <copyright file="ISpell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Interfaces.Spells
{
    using System;
    using System.Collections.Generic;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Creature;

    /// <summary>
    /// The base class for spells.
    /// </summary>
    public abstract class ISpell
    {
        /// <summary>
        /// The unique id for this spell instance.
        /// </summary>
        public Guid ID = new Guid();

        /// <summary>
        /// Lore about the spell.
        /// </summary>
        public List<string> Info;

        /// <summary>
        /// The name of the spell.
        /// </summary>
        public string Name;

        /// <summary>
        /// The amount of power this spell consumes when cast.
        /// </summary>
        public int PowerRequired;

        public int RoundsLeft;

        /// <summary>
        /// The xp value that this ability adds to the creature which has this.
        /// </summary>
        public int XPValue = 0;

        private readonly bool CombatOnly;
        private string ImagePath;

        public int MemorizationDifficulty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ISpell"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="documentationPath"></param>
        /// <param name="lore"></param>
        /// <param name="otherInformation"></param>
        /// <param name="powerRequired"></param>
        /// <param name="roundsLeft"></param>
        /// <param name="imagePath"></param>
        /// <param name="AOE">Area of effect spell?</param>
        protected ISpell(string name, string documentationPath, int powerRequired, int roundsLeft, string imagePath, bool combatOnly)
        {
            this.Name = name;
            this.PowerRequired = powerRequired;
            this.RoundsLeft = roundsLeft;
            this.Info = ResourceGM.GetResource(documentationPath);
            this.ImagePath = imagePath;
            this.CombatOnly = combatOnly;
            this.MemorizationDifficulty = this.PowerRequired * (this.RoundsLeft + 1);
        }

        public bool Cast(List<ICreature> party, List<ICreature> enemies, ICreature caster)
        {
            if (caster.CastingPower >= this.PowerRequired)
            {
                if (this.Go(party, enemies, caster))
                {
                    caster.CastingPower -= this.PowerRequired;
                    return true;
                }
                else
                {
                    Util.Util.WriteLine(caster.Name + " failed to cast " + this.Name);
                    return false;
                }
            }
            else
            {
                Util.Util.WriteLine("Not enough power to cast " + this.Name);
                return false;
            }
        }

        public bool Cast(List<ICreature> party, ICreature caster)
        {
            if (!this.CombatOnly)
            {
                if (caster.CastingPower >= this.PowerRequired)
                {
                    if (this.Go(party, caster))
                    {
                        caster.CastingPower -= this.PowerRequired;
                        return true;
                    }
                    else
                    {
                        Util.Util.WriteLine(caster.Name + " failed to cast " + this.Name);
                        return false;
                    }
                }
                else
                {
                    Util.Util.WriteLine("Not enough power to cast " + this.Name);
                    return false;
                }
            }
            else
            {
                Util.Util.WriteLine(this.Name + " is a combat only spell!");
                return false;
            }
        }

        public void DisplayImage()
        {
            List<string> image = ResourceGM.GetResource(this.ImagePath);
            Util.Util.WriteLine(image);
        }

        /// <summary>
        /// Called whenever the creature tries to take an action.
        /// Returns whether or not the creature is allowed to take an action.
        /// <paramref name="Affected"/>
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="Affected"></param>
        public abstract bool OnAction(List<ICreature> party, List<ICreature> enemies, ICreature Affected);

        /// <summary>
        /// Does stuff if it wants to on the creature's turn. Returns if the creature gets to do anything, or if it just has to end it's turn.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="affected"></param>
        /// <returns></returns>
        public abstract bool OnTurn(List<ICreature> party, List<ICreature> enemies, ICreature affected);

        /// <summary>
        /// Called when it is peace.
        /// </summary>
        /// <param name="party"></param>
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
        /// Called when the spell is cast in peace.
        /// </summary>
        /// <param name="theParty"></param>
        /// <param name="creature"></param>
        /// <returns></returns>
        protected abstract bool Go(List<ICreature> theParty, ICreature creature);

        /// <summary>
        /// Called when the spell is cast.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="party"></param>
        /// <param name="enemies"></param>
        /// <param name="caster"></param>
        /// <returns>Returns if the caster was able to cast the spell.</returns>
        protected abstract bool Go(List<ICreature> party, List<ICreature> enemies, ICreature caster);
    }
}