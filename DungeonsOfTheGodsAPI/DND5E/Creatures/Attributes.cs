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

        /// <summary>
        /// The chance that the creature will be able to resist acid damage and only take half damage.
        /// </summary>
        public Attribute AcidResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist cold damage and only take half damage.
        /// </summary>
        public Attribute ColdResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist fire damage and only take half damage.
        /// </summary>
        public Attribute FireResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist force damage and only take half damage.
        /// </summary>
        public Attribute ForceResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist lightning damage and only take half damage.
        /// </summary>
        public Attribute LightningResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist necrotic damage and only take half damage.
        /// </summary>
        public Attribute NecroticResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist poison damage and only take half damage.
        /// </summary>
        public Attribute PoisonResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist psychic damage and only take half damage.
        /// </summary>
        public Attribute PsychicResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist radiant damage and only take half damage.
        /// </summary>
        public Attribute RadiantResistance { get; }

        /// <summary>
        /// The chance that the creature will be able to resist thunder damage and only take half damage.
        /// </summary>
        public Attribute ThunderResistance { get; }
    }
}
