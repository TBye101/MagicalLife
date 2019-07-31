using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator
{
    /// <summary>
    /// Used to modify dungeon translation nodes in a specific fashion to satisfy their connections while providing real tile mapping coordinates relative to the entrance.
    /// </summary>
    public interface IDungeonGraphArranger
    {
        /// <summary>
        /// Modifies dungeon translation nodes in a specific fashion to satisfy their connections while providing real tile mapping coordinates relative to the entrance.
        /// </summary>
        Dictionary<Guid, DungeonTranslationNode> Arrange(Dictionary<Guid, DungeonTranslationNode> nodes);
    }
}
