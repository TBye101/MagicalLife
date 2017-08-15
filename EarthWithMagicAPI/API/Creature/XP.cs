using System;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Holds information about a creature's xp.
    /// </summary>
    public class XP
    {
        /// <summary>
        /// The number of level ups the creature needs to do.
        /// </summary>
        public int LevelUpsAvailible = 0;

        /// <summary>
        /// The level of creature.
        /// </summary>
        public int CreatureLevel;

        /// <summary>
        /// Our current xp to the next level.
        /// </summary>
        public int CurrentXP = 0;

        /// <summary>
        /// The xp needed to level up.
        /// </summary>
        public int XPToNextLevel = 100;

        /// <summary>
        /// The constructor for the xp class.
        /// </summary>
        /// <param name="creatureLevel"></param>
        public XP(int creatureLevel)
        {
            this.CreatureLevel = creatureLevel;
        }

        /// <summary>
        /// Used to add xp to the creature.
        /// </summary>
        /// <param name="xp"></param>
        public void RecieveXP(int xp)
        {
            this.CurrentXP += xp;

            if (this.CurrentXP >= this.XPToNextLevel)
            {
                ++this.CreatureLevel;
                this.CurrentXP -= this.XPToNextLevel;
                ++this.LevelUpsAvailible;
            }
        }

        /// <summary>
        /// Used to remove xp from the character.
        /// </summary>
        /// <param name="xp"></param>
        public void RemoveXP(int xp)
        {
            this.CurrentXP -= xp;
            if (this.CurrentXP < 0)
            {
                this.CurrentXP = 0;
            }
        }
    }
}