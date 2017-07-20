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
        public CreatureAttributes(int gender, int AC, int maxHealth, int health, int dexterity, int strength, int constitution, int charisma, int wisdom, XP xp, int fireResistence, int acidResistence, int poisonResistence, int electricResistence, int coldResistence, int magicResistence, int charmResistence, int sleepResistence, bool needsOxygen, int initiative)
        {
            this.Gender = gender;
            this.AC = AC;
            this.MaxHealth = maxHealth;
            this.Health = health;
            this.Dexterity = dexterity;
            this.Strength = strength;
            this.Constitution = constitution;
            this.Charisma = charisma;
            this.Wisdom = wisdom;
            this.Xp = xp;
            this.FireResistence = fireResistence;
            this.AcidResistence = acidResistence;
            this.PoisonResistence = poisonResistence;
            this.ElectricResistence = electricResistence;
            this.ColdResistence = coldResistence;
            this.MagicResistence = magicResistence;
            this.CharmResistence = charmResistence;
            this.SleepResistence = sleepResistence;
            this.NeedsOxygen = needsOxygen;
            this.Initiative = initiative;
        }

        /// <summary>
        /// 0 = male, 1 = female, -1 = not applicable.
        /// </summary>
        public int Gender = -1;

        /// <summary>
        /// Armor class of the creature.
        /// Damage is reduced by armor class after resistances.
        /// Damage taken is calculated by the following: Damage (After resistance calculations) * AC%.
        /// </summary>
        public int AC;

        /// <summary>
        /// The maximum health of the creature.
        /// </summary>
        public int MaxHealth;

        /// <summary>
        /// The actual health of the creature.
        /// </summary>
        public int Health;

        /// <summary>
        /// The dexterity of the creature.
        /// </summary>
        public int Dexterity;

        /// <summary>
        /// The strength of the creature.
        /// </summary>
        public int Strength;

        /// <summary>
        /// The constitution of the creature.
        /// Constitution affects how many hit points the creature can get.
        /// </summary>
        public int Constitution;

        /// <summary>
        /// The charisma of the creature.
        /// The ability of the creature to sway others.
        /// </summary>
        public int Charisma;

        /// <summary>
        /// The creature's wisdom.
        /// </summary>
        public int Wisdom;

        /// <summary>
        /// Xp information about the creature.
        /// </summary>
        public XP Xp;

        /// <summary>
        /// How much weight the creature can carry around.
        /// </summary>
        public int WeightCapacity;

        #region Resistances

        /// <summary>
        /// The resistance of the creature to fire.
        /// </summary>
        public int FireResistence;

        /// <summary>
        /// The resistance of the creature to acid.
        /// </summary>
        public int AcidResistence;

        /// <summary>
        /// The resistance of the creature to poison.
        /// </summary>
        public int PoisonResistence;

        /// <summary>
        /// The resistance of the creature to electricity.
        /// </summary>
        public int ElectricResistence;

        /// <summary>
        /// The resistance of the creature to cold.
        /// </summary>
        public int ColdResistence;

        /// <summary>
        /// The resistance of the creature to magic.
        /// </summary>
        public int MagicResistence;

        /// <summary>
        /// The resistance of the creature to charms.
        /// </summary>
        public int CharmResistence;

        /// <summary>
        /// The resistance of the creature to sleep (spells and abilities).
        /// </summary>
        public int SleepResistence;

        #endregion Resistances

        /// <summary>
        /// Holds a flag that tells if the creature needs to breath oxygen.
        /// </summary>
        public bool NeedsOxygen;

        /// <summary>
        /// Used to determine the order of creature action.
        /// </summary>
        public int Initiative;
    }
}