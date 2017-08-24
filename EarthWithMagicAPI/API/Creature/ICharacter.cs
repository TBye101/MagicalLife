// <copyright file="ICharacter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCharacters.Classes
{
    using EarthWithMagicAPI.API.Creature;

    public abstract class ICharacter : ICreature
    {
        protected ICharacter(CreatureAttributes attributes, CreatureAbilities abilities, string documentationPath, string imagePath, IAI aI)
            : base(attributes, abilities, documentationPath, imagePath, aI)
        {
        }

        /// <summary>
        /// Called whenever it is time to level up this creature.
        /// The player should control the level up.
        /// </summary>
        public abstract void LevelUp();
    }
}