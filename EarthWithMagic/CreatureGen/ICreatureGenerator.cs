using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagic.CreatureGen
{
    /// <summary>
    /// Generates a monk character by asking the user questions.
    /// </summary>
    public interface ICreatureGenerator
    {
        /// <summary>
        /// Returns the created creature.
        /// </summary>
        /// <returns></returns>
        ICreature Generate();
    }
}
