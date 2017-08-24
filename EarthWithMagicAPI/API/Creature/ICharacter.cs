namespace EarthMagicCharacters.Classes
{
    using EarthWithMagicAPI.API.Creature;

    public abstract class ICharacter : ICreature
    {
        protected ICharacter(CreatureAttributes attributes, CreatureAbilities abilities, string documentationPath, string imagePath, IAI AI)
            : base(attributes, abilities, documentationPath, imagePath, AI)
        {
        }

        /// <summary>
        /// Called whenever it is time to level up this creature.
        /// The player should control the level up.
        /// </summary>
        public abstract void LevelUp();
    }
}