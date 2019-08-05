using System;
using ProtoBuf;

namespace MLAPI.Entity.Experience
{
    /// <summary>
    /// Holds XP data for something.
    /// </summary>
    [ProtoContract]
    public class Xp
    {
        [ProtoMember(1)]
        public UInt64 CurrentXp { get; private set; }

        /// <summary>
        /// The amount of XP that when <see cref="CurrentXp"/> is equal/greater than merits a level up.
        /// </summary>
        [ProtoMember(2)]
        public UInt64 NextLevelXpRequired { get; private set; }

        [ProtoMember(3)]
        public int CurrentLevel { get; private set; }

        [ProtoMember(4)]
        public IXpCalculator XpCalculator { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="currentXp">The current XP of the creature.</param>
        /// <param name="currentLevel">The current level of the creature.</param>
        /// <param name="xpCalculator">The method of calculating XP to the next level.</param>
        public Xp(UInt64 currentXp, int currentLevel, IXpCalculator xpCalculator)
        {
            this.CurrentXp = currentXp;
            this.CurrentLevel = currentLevel;
            this.XpCalculator = xpCalculator;
            this.NextLevelXpRequired += xpCalculator.GetRequiredXp(this.CurrentLevel);
        }

        protected Xp()
        {
            //Protobuf-net constructor
        }

        /// <summary>
        /// Adds XP.
        /// </summary>
        /// <param name="xp"></param>
        public void AddXp(UInt64 xp)
        {
            this.CurrentXp += xp;

            while (this.CurrentXp > this.NextLevelXpRequired)
            {
                this.CurrentLevel++;
                this.NextLevelXpRequired += this.XpCalculator.GetRequiredXp(this.CurrentLevel);
            }
        }

        public void RemoveXp(UInt64 xp)
        {
            this.CurrentXp -= xp;

            //Calculates the threshold for going down a level.
            while (this.CurrentXp < this.XpCalculator.GetRequiredXp(this.CurrentLevel - 1))
            {
                this.NextLevelXpRequired -= this.XpCalculator.GetRequiredXp(this.CurrentLevel - 1);
                this.CurrentLevel--;
            }
        }
    }
}