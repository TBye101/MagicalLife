namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Holds information about the creature's saving throws.
    /// </summary>
    public class SavingThrows
    {
        /// <summary>
        /// The chance out of 100 that the creature will make a dexterity save.
        /// </summary>
        public int DexteritySave;

        /// <summary>
        /// The chance out of 100 that the creature will make a strength save.
        /// </summary>
        public int StrengthSave;

        /// <summary>
        /// The chance out of 100 that the creature will make a constitution save.
        /// </summary>
        public int ConstitutionSave;

        /// <summary>
        /// The chance out of 100 that the creature will make a charisma save.
        /// </summary>
        public int CharismaSave;

        /// <summary>
        /// The chance out of 100 that the creature will make a wisdom save.
        /// </summary>
        public int WisdomSave;

        /// <summary>
        /// The chance out of 100 that the creature will make a save vs death.
        /// </summary>
        public int SaveVsDeath;

        /// <summary>
        /// The chance out of 100 that the creature will make a save vs fear.
        /// </summary>
        public int SaveVsFear;
    }
}