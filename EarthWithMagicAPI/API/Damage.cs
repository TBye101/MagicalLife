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
        public Dice.Die AcidDamage;

        /// <summary>
        /// How much poison damage is dealt every turn.
        /// </summary>
        public Dice.Die PoisonDamage;

        /// <summary>
        /// How much electric damage to deal.s
        /// </summary>
        public Dice.Die ElectricDamage;

        /// <summary>
        /// How much fire damage to deal.
        /// </summary>
        public Dice.Die FireDamage;

        /// <summary>
        /// How much cold damage to deal.
        /// </summary>
        public Dice.Die ColdDamage;

        /// <summary>
        /// How much pure magic damage.
        /// </summary>
        public Dice.Die MagicDamage;

        /// <summary>
        /// How much piercing damage to deal. (Ex: Arrows, stabs)
        /// </summary>
        public Dice.Die PiercingDamage;

        /// <summary>
        /// How much slashing damage to deal. (Ex: Sword slashes)
        /// </summary>
        public Dice.Die SlashingDamage;

        /// <summary>
        /// How much blunt damage to deal. (Ex: Rock, club)
        /// </summary>
        public Dice.Die BluntDamage;

        /// <summary>
        /// The constructor for the damage class.
        /// </summary>
        public Damage(Dice.Die acidDamage, Dice.Die poisonDamage, Dice.Die electricDamage, Dice.Die fireDamage, Dice.Die coldDamage, Dice.Die magicDamage, Dice.Die piercingDamage, Dice.Die slashingDamage, Dice.Die bluntDamage)
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