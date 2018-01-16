using MagicalLifeAPI.Entities.Entity_Components.Movement_Rules;
using MagicalLifeAPI.Entities.Util;
using MagicalLifeAPI.Universal;

namespace MagicalLifeAPI.Entities
{
    /// <summary>
    /// All living things inherit from this, and utilize it.
    /// </summary>
    public abstract class Living : Unique
    {
        /// <summary>
        /// How many hit points this creature has.
        /// </summary>
        public Attribute Health { get; set; }

        /// <summary>
        /// How fast this creature can move.
        /// </summary>
        public Attribute MovementSpeed { get; set; }

        /// <summary>
        /// The rules concerning where the creature is allowed to move.
        /// </summary>
        public IMovementRule MovementRules { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Living"/> base class.
        /// </summary>
        /// <param name="health"></param>
        /// <param name="movementSpeed"></param>
        public Living(int health, int movementSpeed, IMovementRule movementRules)
        {
            this.Health = new Attribute(health);
            this.MovementSpeed = new Attribute(movementSpeed);
            this.MovementRules = movementRules;
        }

        /// <summary>
        /// Returns the name of the texture.
        /// </summary>
        /// <returns></returns>
        public abstract string GetTextureName();
    }
}