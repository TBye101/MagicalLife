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
        public int LevelUpsAvailible;

        /// <summary>
        /// The level of creature.
        /// </summary>
        public int CreatureLevel;

        /// <summary>
        /// Our current xp to the next level.
        /// </summary>
        public UInt64 CurrentXP = 0;

        /// <summary>
        /// The xp needed to level up.
        /// </summary>
        public UInt64 XPToNextLevel = 100;

        /// <summary>
        /// The constructor for the xp class.
        /// </summary>
        public XP(int creatureLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used to add xp to the creature.
        /// </summary>
        /// <param name="xp"></param>
        public void RecieveXP(UInt64 xp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used to remove xp from the character.
        /// </summary>
        /// <param name="xp"></param>
        public void RemoveXP(UInt64 xp)
        {
            throw new NotImplementedException();
        }
    }
}