namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Holds information about the creature's saving throws.
    /// </summary>
    public class SavingThrows
    {
        /// <summary>
        /// The base chance out of 100 that the creature will make a charisma save.
        /// </summary>
        public int BaseCharismaSave;

        /// <summary>
        /// The base chance out of 100 that the creature will make a constitution save.
        /// </summary>
        public int BaseConstitutionSave;

        /// <summary>
        /// The base chance out of 100 that the creature will make a dexterity save.
        /// </summary>
        public int BaseDexteritySave;

        /// <summary>
        /// The base chance out of 100 that the creature will make a save vs death.
        /// </summary>
        public int BaseSaveVsDeath;

        /// <summary>
        /// The base chance out of 100 that the creature will make a save vs fear.
        /// </summary>
        public int BaseSaveVsFear;

        /// <summary>
        /// The base chance out of 100 that the creature will make a strength save.
        /// </summary>
        public int BaseStrengthSave;

        /// <summary>
        /// The base chance out of 100 that the creature will make a wisdom save.
        /// </summary>
        public int BaseWisdomSave;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int CharismaSave;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int ConstitutionSave;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int DexteritySave;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int SaveVsDeath;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int SaveVsFear;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int StrengthSave;

        /// <summary>
        /// The current chance out of 100 that the creature will make the save.
        /// </summary>
        public int WisdomSave;

        public SavingThrows(int baseDexteritySave, int baseStrengthSave, int baseConstitutionSave, int baseCharismaSave, int baseWisdomSave, int baseSaveVsDeath, int baseSaveVsFear)
        {
            this.BaseDexteritySave = baseDexteritySave;
            this.BaseStrengthSave = baseStrengthSave;
            this.BaseConstitutionSave = baseConstitutionSave;
            this.BaseCharismaSave = baseCharismaSave;
            this.BaseWisdomSave = baseWisdomSave;
            this.BaseSaveVsDeath = baseSaveVsDeath;
            this.BaseSaveVsFear = baseSaveVsFear;
        }
    }
}