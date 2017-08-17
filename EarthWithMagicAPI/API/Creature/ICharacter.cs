using EarthWithMagicAPI.API.Creature;

namespace EarthMagicCharacters.Classes
{
    public abstract class ICharacter : ICreature
    {
        protected ICharacter(CreatureAttributes attributes, CreatureAbilities abilities) : base(attributes, abilities)
        { }

        /// <summary>
        /// Called whenever it is time to level up this creature.
        /// The player should control the level up.
        /// </summary>
        public abstract void LevelUp();
    }
}