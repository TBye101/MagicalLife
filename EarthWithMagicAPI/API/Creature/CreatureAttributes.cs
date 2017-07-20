namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Some stats of a creature.
    /// </summary>
    public class CreatureAttributes
    {
        /// <summary>
        /// Armor class of the creature.
        /// Damage is reduced by armor class after resistances.
        /// Damage taken is calculated by the following: Damage (After resistance calculations) * AC%.
        /// </summary>
        public int AC;

        /// <summary>
        /// The health of the creature.
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

        #endregion
    }
}