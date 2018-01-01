using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures.Character_Generation.Character_Creation_Rules
{
    /// <summary>
    /// Used to unify the creation rules for characters.
    /// </summary>
    public interface ICharacterOptionsCompatibility
    {
        /// <summary>
        /// Gets all availible options for characters from the specified abilities.
        /// </summary>
        /// <param name="abilities"></param>
        /// <returns></returns>
        List<CharacterOption> GetOptions(Abilities abilities);
    }
}
