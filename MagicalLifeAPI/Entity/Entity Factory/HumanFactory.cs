using MagicalLifeAPI.Entities.Humanoid;
using MagicalLifeAPI.Util;
using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.Entities.Entity_Factory
{
    /// <summary>
    /// Used to initialize a new human properly.
    /// </summary>
    public class HumanFactory
    {
        /// <summary>
        /// The maximum number of hit points that a human could get per level.
        /// </summary>
        private readonly int MaxHumanHealthPerLevel = 10;

        /// <summary>
        /// The minimum number of hit points that a human could get per level.
        /// </summary>
        private readonly int MinHumanHealthPerLevel = 2;

        /// <summary>
        /// The fastest a human could possibly be without starting down a class path.
        /// </summary>
        private readonly double MaxHumanMovement = .1;

        /// <summary>
        /// The slowest a human could possibly be without some significant injuries.
        /// </summary>
        private readonly double MinHumanMovement = .05;

        /// <summary>
        /// Returns a fully generated human character.
        /// </summary>
        /// <returns></returns>
        public Human GenerateHuman(Point location)
        {
            int health = StaticRandom.Rand(this.MinHumanHealthPerLevel, this.MaxHumanHealthPerLevel + 1);
            double movement = StaticRandom.Rand(this.MinHumanMovement, this.MaxHumanMovement + 1);

            return new Human(health, movement, location);
        }
    }
}