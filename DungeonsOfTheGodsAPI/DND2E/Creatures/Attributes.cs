using System.Data;
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
            this.Strength = new Attribute(strength);
            this.Dexterity = new Attribute(dexterity);
            this.Constitution = new Attribute(constitution);
            this.Wisdom = new Attribute(wisdom);
            this.Intelligence = new Attribute(intelligence);
        }

        public Attributes(Attribute strength, Attribute dexterity, Attribute constitution, Attribute wisdom, Attribute intelligence)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Constitution = constitution;
            this.Wisdom = wisdom;
            this.Intelligence = intelligence;
        }

        /// <summary>
        /// How strong the creature is.
        /// </summary>
        public Attribute Strength { get; }

        /// <summary>
        /// How nimble the creature is.
        /// </summary>
        public Attribute Dexterity { get; }

        /// <summary>
        /// How tough the creature is.
        /// </summary>
        public Attribute Constitution { get; }

        /// <summary>
        /// How wise the creature is.
        /// </summary>
        public Attribute Wisdom { get; }

        /// <summary>
        /// How smart the creature is.
        /// </summary>
        public Attribute Intelligence { get; }
    }
}
