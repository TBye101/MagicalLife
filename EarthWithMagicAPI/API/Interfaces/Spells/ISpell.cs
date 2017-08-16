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
        /// After resting, this is how many uses this ability could be used.
        /// </summary>
        public int MaxUses;

        /// <summary>
        /// The amount of uses that we have available right now.
        /// </summary>
        public int AvailibleUses;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lore"></param>
        /// <param name="otherInformation"></param>
        /// <param name="powerRequired"></param>
        /// <param name="AOE">Area of effect spell?</param>
        protected ISpell(string name, List<string> lore, List<string> otherInformation, int powerRequired, bool AOE, int maxUses, int roundsLeft)
        {
            this.Name = name;
            this.Lore = lore;
            this.OtherInformation = otherInformation;
            this.PowerRequired = powerRequired;
            this.AOESpell = AOE;
            this.MaxUses = maxUses;
            this.RoundsLeft = roundsLeft;
        }

        /// <summary>
        /// Called when the spell is cast.
        /// </summary>
        /// <param name="creature"></param>
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