// <copyright file="Damage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API
{
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Holds all of the different types of damages.
    /// </summary>
    public class Damage
    {
        /// <summary>
        /// How much acid damage to deal.
        /// </summary>
        public Die AcidDamage;

        /// <summary>
        /// How much blunt damage to deal. (Ex: Rock, club)
        /// </summary>
        public Die BluntDamage;

        /// <summary>
        /// How much cold damage to deal.
        /// </summary>
        public Die ColdDamage;

        /// <summary>
        /// How much electric damage to deal.s
        /// </summary>
        public Die ElectricDamage;

        /// <summary>
        /// How much fire damage to deal.
        /// </summary>
        public Die FireDamage;

        /// <summary>
        /// How much pure magic damage.
        /// </summary>
        public Die MagicDamage;

        /// <summary>
        /// How much piercing damage to deal. (Ex: Arrows, stabs)
        /// </summary>
        public Die PiercingDamage;

        /// <summary>
        /// How much poison damage is dealt every turn.
        /// </summary>
        public Die PoisonDamage;

        /// <summary>
        /// How much slashing damage to deal. (Ex: Sword slashes)
        /// </summary>
        public Die SlashingDamage;

        /// <summary>
        /// The constructor for the damage class.
        /// </summary>
        /// <param name="acidDamage"></param>
        /// <param name="poisonDamage"></param>
        /// <param name="electricDamage"></param>
        /// <param name="fireDamage"></param>
        /// <param name="coldDamage"></param>
        /// <param name="magicDamage"></param>
        /// <param name="piercingDamage"></param>
        /// <param name="slashingDamage"></param>
        /// <param name="bluntDamage"></param>
        public Damage(Die acidDamage, Die poisonDamage, Die electricDamage, Die fireDamage, Die coldDamage, Die magicDamage, Die piercingDamage, Die slashingDamage, Die bluntDamage)
        {
            this.AcidDamage = acidDamage;
            this.PoisonDamage = poisonDamage;
            this.ElectricDamage = electricDamage;
            this.FireDamage = fireDamage;
            this.ColdDamage = coldDamage;
            this.MagicDamage = magicDamage;
            this.PiercingDamage = piercingDamage;
            this.SlashingDamage = slashingDamage;
            this.BluntDamage = bluntDamage;
        }
    }
}