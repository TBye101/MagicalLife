using Microsoft.Win32.SafeHandles;
namespace EarthWithMagicAPI.API
{
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Used to differentiate between damage types.
    /// </summary>
    public enum DamageType
    {
        Acid, Blunt, Cold, Electric, Fire, Magic, Piercing, Poison, Slashing
    }

    /// <summary>
    /// Holds all of the different types of damages.
    /// </summary>
    public class Damage
    {
        /// <summary>
        /// How much acid damage to deal.
        /// </summary>
        private Die acidDamage = Die.Zero();

        /// <summary>
        /// How much blunt damage to deal. (Ex: Rock, club)
        /// </summary>
        private Die bluntDamage = Die.Zero();

        /// <summary>
        /// How much cold damage to deal.
        /// </summary>
        private Die coldDamage = Die.Zero();

        /// <summary>
        /// How much electric damage to deal.s
        /// </summary>
        private Die electricDamage = Die.Zero();

        /// <summary>
        /// How much fire damage to deal.
        /// </summary>
        private Die fireDamage = Die.Zero();

        /// <summary>
        /// How much pure magic damage.
        /// </summary>
        private Die magicDamage = Die.Zero();

        /// <summary>
        /// How much piercing damage to deal. (Ex: Arrows, stabs)
        /// </summary>
        private Die piercingDamage = Die.Zero();

        /// <summary>
        /// How much poison damage is dealt every turn.
        /// </summary>
        private Die poisonDamage = Die.Zero();

        /// <summary>
        /// How much slashing damage to deal. (Ex: Sword slashes)
        /// </summary>
        private Die slashingDamage = Die.Zero();

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
        /// This constructor is used to initialize damage to all zeros except for one type of damage.
        /// </summary>
        /// <param name="damage">The dice roll of the non zero damage type.</param>
        /// <param name="type">The type of damage to not set to zero.</param>
        public Damage(Die damage, DamageType type)
        {
            switch (type)
            {
                case DamageType.Acid:
                    this.AcidDamage = damage;
                    break;
                case DamageType.Blunt:
                    this.BluntDamage = damage;
                    break;
                case DamageType.Cold:
                    this.ColdDamage = damage;
                    break;
                case DamageType.Electric:
                    this.ElectricDamage = damage;
                    break;
                case DamageType.Fire:
                    this.FireDamage = damage;
                    break;
                case DamageType.Magic:
                    this.MagicDamage = damage;
                    break;
                case DamageType.Piercing:
                    this.PiercingDamage = damage;
                    break;
                case DamageType.Poison:
                    this.PoisonDamage = damage;
                    break;
                case DamageType.Slashing:
                    this.SlashingDamage = damage;
                    break;
            }
        }

        public Die AcidDamage
        {
            get
            {
                return this.acidDamage;
            }

            set
            {
                this.acidDamage = value;
            }
        }

        public Die BluntDamage
        {
            get
            {
                return this.bluntDamage;
            }

            set
            {
                this.bluntDamage = value;
            }
        }

        public Die ColdDamage
        {
            get
            {
                return this.coldDamage;
            }

            set
            {
                this.coldDamage = value;
            }
        }

        public Die ElectricDamage
        {
            get
            {
                return this.electricDamage;
            }

            set
            {
                this.electricDamage = value;
            }
        }

        public Die FireDamage
        {
            get
            {
                return this.fireDamage;
            }

            set
            {
                this.fireDamage = value;
            }
        }

        public Die MagicDamage
        {
            get
            {
                return this.magicDamage;
            }

            set
            {
                this.magicDamage = value;
            }
        }

        public Die PiercingDamage
        {
            get
            {
                return this.piercingDamage;
            }

            set
            {
                this.piercingDamage = value;
            }
        }

        public Die PoisonDamage
        {
            get
            {
                return this.poisonDamage;
            }

            set
            {
                this.poisonDamage = value;
            }
        }

        public Die SlashingDamage
        {
            get
            {
                return this.slashingDamage;
            }

            set
            {
                this.slashingDamage = value;
            }
        }
    }
}