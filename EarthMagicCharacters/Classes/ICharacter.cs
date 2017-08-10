using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicCharacters.Classes
{
    public abstract class ICharacter : ICreature
    {
        /// <summary>
        /// Called whenever it is time to level up this creature.
        /// The player should control the level up.
        /// </summary>
        public abstract void LevelUp();
    }
}
