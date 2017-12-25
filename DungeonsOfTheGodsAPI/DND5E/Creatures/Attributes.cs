using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E.Creatures
{
    /// <summary>
    /// Holds and manages many attribures of a creature.
    /// </summary>
    public class Attributes
    {
        public Attributes(int strength, int dexterity, int constitution, int wisdom, int intelligence)
        {
        }

        /// <summary>
        /// How strong the creature is.
        /// </summary>
        public int Strength { get; }

        /// <summary>
        /// How nimble the creature is.
        /// </summary>
        public int Dexterity { get; }

        /// <summary>
        /// How tough the creature is.
        /// </summary>
        public int Constitution { get; }

        /// <summary>
        /// How wise the creature is.
        /// </summary>
        public int Wisdom { get; }

        /// <summary>
        /// How smart the creature is.
        /// </summary>
        public int Intelligence { get; }
    }
}
