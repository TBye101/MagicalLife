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
        private Die acidDamage;

        /// <summary>
        /// How much blunt damage to deal. (Ex: Rock, club)
        /// </summary>
        private Die bluntDamage;

        /// <summary>
        /// How much cold damage to deal.
        /// </summary>
        private Die coldDamage;

        /// <summary>
        /// How much electric damage to deal.s
        /// </summary>
        private Die electricDamage;

        /// <summary>
        /// How much fire damage to deal.
        /// </summary>
        private Die fireDamage;

        /// <summary>
        /// How much pure magic damage.
        /// </summary>
        private Die magicDamage;

        /// <summary>
        /// How much piercing damage to deal. (Ex: Arrows, stabs)
        /// </summary>
        private Die piercingDamage;

        /// <summary>
        /// How much poison damage is dealt every turn.
        /// </summary>
        private Die poisonDamage;

        /// <summary>
        /// How much slashing damage to deal. (Ex: Sword slashes)
        /// </summary>
        private Die slashingDamage;

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