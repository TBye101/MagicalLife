using ProtoBuf;
using System;

namespace MagicalLifeAPI.Entity.Experience
{
    /// <summary>
    /// Holds XP data for something.
    /// </summary>
    [ProtoContract]
    public class XP
    {
        [ProtoMember(1)]
        public UInt64 CurrentXP { get; private set; }

        /// <summary>
        /// The amount of XP that when <see cref="CurrentXP"/> is equal/greater than merits a level up.
        /// </summary>
        [ProtoMember(2)]
        public UInt64 NextLevelXPRequired { get; private set; }

        [ProtoMember(3)]
        public int CurrentLevel { get; private set; }

        [ProtoMember(4)]
        public IXPCalculator XPCalculator { get; private set; }

        /// <param name="currentXP">The current XP of the creature.</param>
        /// <param name="currentLevel">The current level of the creature.</param>
        /// <param name="xpCalculator">The method of calculating XP to the next level.</param>
        public XP(UInt64 currentXP, int currentLevel, IXPCalculator xpCalculator)
        {
            this.CurrentXP = currentXP;
            this.CurrentLevel = currentLevel;
            this.XPCalculator = xpCalculator;
            this.NextLevelXPRequired += xpCalculator.GetRequiredXP(this.CurrentLevel);
        }

        protected XP()
        {
            //Protobuf-net constructor
        }

        /// <summary>
        /// Adds XP.
        /// </summary>
        /// <param name="xp"></param>
        public void AddXP(UInt64 xp)
        {
            this.CurrentXP += xp;

            while (this.CurrentXP > this.NextLevelXPRequired)
            {
                this.CurrentLevel++;
                this.NextLevelXPRequired += this.XPCalculator.GetRequiredXP(this.CurrentLevel);
            }
        }

        public void RemoveXP(UInt64 xp)
        {
            this.CurrentXP -= xp;

            //Calculates the threshold for going down a level.
            while (this.CurrentXP < this.XPCalculator.GetRequiredXP(this.CurrentLevel - 1))
            {
                this.NextLevelXPRequired -= this.XPCalculator.GetRequiredXP(this.CurrentLevel - 1);
                this.CurrentLevel--;
            }
        }
    }
}