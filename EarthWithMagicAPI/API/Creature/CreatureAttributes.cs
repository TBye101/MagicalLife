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
        public CreatureAttributes(Gender gender = Gender.Unspecified, Alignment alignment = Alignment.LawfulGood, Race race = Race.Human, double AC = 0, double maxHealth = 0, double health = 0, int dexterity = 0, int strength = 0,
            int constitution = 0, int charisma = 0, int wisdom = 0, double fireResistence = 0, double acidResistence = 0,
            double poisonResistence = 0, double electricResistence = 0, double coldResistence = 0, double magicResistence = 0, double charmResistence = 0,
            double sleepResistence = 0, bool needsOxygen = false, int initiative = 0, double toHit = 0, double dodge = 0, int intelligence = 0)
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
            this.BaseIntelligence = intelligence;
            this.Race = race;
            this.Alignment = alignment;
        }

        /// <summary>
        /// The chance that we will successfully hit with the currently equipped weapon.
        /// </summary>
        public double BaseToHit;
        public double ToHit;

        /// <summary>
        /// The gender of the creature.
        /// </summary>
        public Gender Gender = Gender.Unspecified;

        /// <summary>
        /// The race of the creature.
        /// </summary>
        public Race Race = Race.Unspecified;

        /// <summary>
        /// The alignment of the creature.
        /// </summary>
        public Alignment Alignment;

        /// <summary>
        /// Armor class of the creature.
        /// Damage is reduced by armor class after resistances.
        /// Damage taken is calculated by the following: Damage (After resistance calculations) * AC%.
        /// </summary>
        public double BaseAC;
        public double AC;

        /// <summary>
        /// The maximum health of the creature.
        /// </summary>
        public double BaseHealth;

        /// <summary>
        /// The actual health of the creature.
        /// </summary>
        public double Health;

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
        public XP XP = new XP(1);

        /// <summary>
        /// How much weight the creature can carry around.
        /// </summary>
        public int WeightCapacity;

        #region Resistances

        /// <summary>
        /// The resistance of the creature to fire.
        /// </summary>
        public double BaseFireResistance;
        public double FireResistance;

        /// <summary>
        /// The resistance of the creature to acid.
        /// </summary>
        public double BaseAcidResistance;
        public double AcidResistance;

        /// <summary>
        /// The resistance of the creature to poison.
        /// </summary>
        public double BasePoisonResistance;
        public double PoisonResistance;

        /// <summary>
        /// The resistance of the creature to electricity.
        /// </summary>
        public double BaseElectricResistance;
        public double ElectricResistance;

        /// <summary>
        /// The resistance of the creature to cold.
        /// </summary>
        public double BaseColdResistance;
        public double ColdResistance;

        /// <summary>
        /// The resistance of the creature to magic.
        /// </summary>
        public double BaseMagicResistance;
        public double MagicResistance;

        /// <summary>
        /// The resistance of the creature to charms.
        /// </summary>
        public double BaseCharmResistance;
        public double CharmResistance;

        /// <summary>
        /// The resistance of the creature to sleep (spells and abilities).
        /// </summary>
        public double BaseSleepResistance;
        public double SleepResistance;

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
        public double BaseDodge;
        public double Dodge;

        /// <summary>
        /// The intelligence of the creature.
        /// </summary>
        public int BaseIntelligence;

        /// <summary>
        /// The current intelligence of the creature.
        /// </summary>
        public int Intelligence;

        public void Rest()
        {
            this.ToHit = this.BaseToHit;
            this.AC = this.BaseAC;
            this.Health++;

            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }

            this.Dexterity = this.BaseDexterity;
            this.Strength = this.BaseStrength;
            this.Constitution = this.BaseConstitution;
            this.Charisma = this.BaseCharisma;
            this.Wisdom = this.BaseWisdom;
            this.FireResistance = this.BaseFireResistance;
            this.AcidResistance = this.BaseAcidResistance;
            this.PoisonResistance = this.BasePoisonResistance;
            this.ElectricResistance = this.BaseElectricResistance;
            this.ColdResistance = this.BaseColdResistance;
            this.MagicResistance = this.BaseMagicResistance;
            this.CharmResistance = this.BaseCharmResistance;
            this.SleepResistance = this.BaseSleepResistance;
            this.Initiative = this.BaseInitiative;
            this.Dodge = this.BaseDodge;
            this.Intelligence = this.BaseIntelligence;
        }
    }
}