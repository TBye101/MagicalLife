namespace EarthWithMagicAPI.API.Interfaces.Spells
{
    using System;
    using System.Collections.Generic;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Creature;

    public abstract class IPrayer
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

        public int RoundsLeft;

        /// <summary>
        /// The xp value that this ability adds to the creature which has this.
        /// </summary>
        public int XPValue = 0;

        private readonly bool CombatOnly;
        private string ImagePath;

        public int MemorizationDifficulty;

        /// <summary>
        /// Initializes a new instance of the <see cref="IPrayer"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="documentationPath"></param>
        /// <param name="lore"></param>
        /// <param name="otherInformation"></param>
        /// <param name="powerRequired"></param>
        /// <param name="roundsLeft"></param>
        /// <param name="imagePath"></param>
        /// <param name="AOE">Area of effect spell?</param>
        protected IPrayer(string name, string documentationPath, int memorizationDifficulty, int roundsLeft, string imagePath, bool combatOnly)
        {
            this.Name = name;
            this.RoundsLeft = roundsLeft;
            this.Info = ResourceGM.GetResource(documentationPath);
            this.ImagePath = imagePath;
            this.CombatOnly = combatOnly;
            this.MemorizationDifficulty = memorizationDifficulty;
        }

        public bool Cast(List<ICreature> party, List<ICreature> enemies, ICreature caster)
        {
            if (caster.Abilities.Prayers > 0)
            {
                if (this.Go(party, enemies, caster))
                {
                    caster.Abilities.Prayers--;
                    return true;
                }
                else
                {
                    Util.Util.WriteLine(caster.Name + " failed to pray " + this.Name);
                    return false;
                }
            }
            else
            {
                Util.Util.WriteLine("Not enough faith to cast " + this.Name);
                return false;
            }
        }

        public bool Cast(List<ICreature> party, ICreature caster)
        {
            if (!this.CombatOnly)
            {
                if (caster.Abilities.Prayers > 0)
                {
                    if (this.Go(party, caster))
                    {
                        caster.Abilities.Prayers--;
                        return true;
                    }
                    else
                    {
                        Util.Util.WriteLine(caster.Name + " failed to pray " + this.Name);
                        return false;
                    }
                }
                else
                {
                    Util.Util.WriteLine("Not enough faith to cast " + this.Name);
                    return false;
                }
            }
            else
            {
                Util.Util.WriteLine(this.Name + " is a combat only prayer!");
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
        /// <returns></returns>
        public abstract bool OnAction(List<ICreature> party, List<ICreature> enemies, ICreature Affected);

        /// <summary>
        /// Does stuff if it wants to on the creature's turn. Returns if the creature gets to do anything, or if it just has to end it's turn.
        /// </summary>
        /// <param name="Party"></param>
        /// <param name="Enemies"></param>
        /// <param name="Affected"></param>
        /// <returns></returns>
        public abstract bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected);

        /// <summary>
        /// Called when it is peace.
        /// </summary>
        /// <param name="Party"></param>
        /// <param name="Affected"></param>
        /// <returns></returns>
        public abstract bool OnTurn(List<ICreature> Party, ICreature Affected);

        /// <summary>
        /// Called when the creature's affect wears off.
        /// </summary>
        /// <param name="Party"></param>
        /// <param name="Enemies"></param>
        /// <param name="Affected"></param>
        public abstract void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected);

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
        /// <param name="Party"></param>
        /// <param name="Enemies"></param>
        /// <param name="Caster"></param>
        /// <returns>Returns if the caster was able to cast the spell.</returns>
        protected abstract bool Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster);
    }
}
