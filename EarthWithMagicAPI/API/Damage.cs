using EarthWithMagicAPI.API.Util;

namespace EarthWithMagicAPI.API
{
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