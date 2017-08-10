namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Some stats of a creature.
    /// </summary>
    public class CreatureAttributes
    {
        /// <summary>
        /// The instructor for the CreatureAttributes class.
        /// </summary>
        /// <param name="gender">0 = male, 1 = female, -1 = not applicable.</param>
        /// <param name="AC">Armor class of the creature. Damage is reduced by armor class after resistances. Damage taken is calculated by the following: Damage (After resistance calculations) * AC%.</param>
        /// <param name="maxHealth">The maximum health of the creature.</param>
        /// <param name="health">The actual health of the creature.</param>
        /// <param name="dexterity">The dexterity of the creature.</param>
        /// <param name="strength">The strength of the creature.</param>
        /// <param name="constitution">The constitution of the creature. Constitution affects how many hit points the creature can get.</param>
        /// <param name="charisma">The charisma of the creature. The ability of the creature to sway others.</param>
        /// <param name="wisdom">The creature's wisdom.</param>
        /// <param name="xp">Xp information about the creature.</param>
        /// <param name="fireResistence">The resistance of the creature to fire.</param>
        /// <param name="acidResistence">The resistance of the creature to acid.</param>
        /// <param name="poisonResistence">The resistance of the creature to poison.</param>
        /// <param name="electricResistence">The resistance of the creature to electricity.</param>
        /// <param name="coldResistence">The resistance of the creature to cold.</param>
        /// <param name="magicResistence">resistance of the creature to magic.</param>
        /// <param name="charmResistence">The resistance of the creature to charms.</param>
        /// <param name="sleepResistence">The resistance of the creature to sleep (spells and abilities).</param>
        /// <param name="needsOxygen">Holds a flag that tells if the creature needs to breath oxygen.</param>
        /// <param name="initiative">Used to determine the order of creature action.</param>
        /// <param name="toHit">Used to determine if we will hit a creature with our current state of equipment.</param>
        /// <param name="dodge">The chance that the character will dodge something.</param>
        public CreatureAttributes(Gender gender, int AC, int maxHealth, int health, int dexterity, int strength,
            int constitution, int charisma, int wisdom, XP xp, int fireResistence, int acidResistence,
            int poisonResistence, int electricResistence, int coldResistence, int magicResistence, int charmResistence,
            int sleepResistence, bool needsOxygen, int initiative, int toHit, int dodge)
        {
            this.Gender = gender;
            this.BaseAC = AC;
            this.BaseHealth = maxHealth;
            this.Health = health;
            this.BaseDexterity = dexterity;
            this.BaseStrength = strength;
            this.BaseConstitution = constitution;
            this.BaseCharisma = charisma;
            this.BaseWisdom = wisdom;
            this.BaseXP = xp;
            this.BaseFireResistance = fireResistence;
            this.BaseAcidResistance = acidResistence;
            this.BasePoisonResistance = poisonResistence;
            this.BaseElectricResistance = electricResistence;
            this.BaseColdResistance = coldResistence;
            this.BaseMagicResistance = magicResistence;
            this.BaseCharmResistance = charmResistence;
            this.BaseSleepResistance = sleepResistence;
            this.NeedsOxygen = needsOxygen;
            this.BaseInitiative = initiative;
            this.BaseToHit = toHit;
            this.BaseDodge = dodge;
        }

        /// <summary>
        /// The chance that we will successfully hit with the currently equipped weapon.
        /// </summary>
        public int BaseToHit;
        public int ToHit;

        /// <summary>
        /// The gender of the creature.
        /// </summary>
        public Gender Gender = Gender.Unspecified;

        /// <summary>
        /// Armor class of the creature.
        /// Damage is reduced by armor class after resistances.
        /// Damage taken is calculated by the following: Damage (After resistance calculations) * AC%.
        /// </summary>
        public int BaseAC;
        public int AC;

        /// <summary>
        /// The maximum health of the creature.
        /// </summary>
        public int BaseHealth;

        /// <summary>
        /// The actual health of the creature.
        /// </summary>
        public int Health;

        /// <summary>
        /// The dexterity of the creature.
        /// </summary>
        public int BaseDexterity;
        public int Dexterity;

        /// <summary>
        /// The strength of the creature.
        /// </summary>
        public int BaseStrength;
        public int Strength;

        /// <summary>
        /// The constitution of the creature.
        /// Constitution affects how many hit points the creature can get.
        /// </summary>
        public int BaseConstitution;
        public int Constitution;

        /// <summary>
        /// The charisma of the creature.
        /// The ability of the creature to sway others.
        /// </summary>
        public int BaseCharisma;
        public int Charisma;

        /// <summary>
        /// The creature's wisdom.
        /// </summary>
        public int BaseWisdom;
        public int Wisdom;

        /// <summary>
        /// Xp information about the creature.
        /// </summary>
        public XP BaseXP;
        public XP XP;

        /// <summary>
        /// How much weight the creature can carry around.
        /// </summary>
        public int WeightCapacity;

        #region Resistances

        /// <summary>
        /// The resistance of the creature to fire.
        /// </summary>
        public int BaseFireResistance;
        public int FireResistance;

        /// <summary>
        /// The resistance of the creature to acid.
        /// </summary>
        public int BaseAcidResistance;
        public int AcidResistance;

        /// <summary>
        /// The resistance of the creature to poison.
        /// </summary>
        public int BasePoisonResistance;
        public int PoisonResistance;

        /// <summary>
        /// The resistance of the creature to electricity.
        /// </summary>
        public int BaseElectricResistance;
        public int ElectricResistance;

        /// <summary>
        /// The resistance of the creature to cold.
        /// </summary>
        public int BaseColdResistance;
        public int ColdResistance;

        /// <summary>
        /// The resistance of the creature to magic.
        /// </summary>
        public int BaseMagicResistance;
        public int MagicResistance;

        /// <summary>
        /// The resistance of the creature to charms.
        /// </summary>
        public int BaseCharmResistance;
        public int CharmResistance;

        /// <summary>
        /// The resistance of the creature to sleep (spells and abilities).
        /// </summary>
        public int BaseSleepResistance;
        public int SleepResistance;

        #endregion Resistances

        /// <summary>
        /// Holds a flag that tells if the creature needs to breath oxygen.
        /// </summary>
        public bool NeedsOxygen;

        /// <summary>
        /// Used to determine the order of creature action.
        /// </summary>
        public int BaseInitiative;
        public int Initiative;

        /// <summary>
        /// The chance that the creature will dodge.
        /// </summary>
        public int BaseDodge;
        public int Dodge;
    }
}