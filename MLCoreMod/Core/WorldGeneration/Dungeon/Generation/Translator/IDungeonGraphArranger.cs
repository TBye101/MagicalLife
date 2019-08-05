using System;
using System.Collections.Generic;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    /// <summary>
    /// Used to modify dungeon translation nodes in a specific fashion to satisfy their connections while providing real tile mapping coordinates relative to the entrance.
    /// </summary>
    public interface IDungeonGraphArranger
    {
        void Setup(Dictionary<Guid, DungeonTranslationNode> nodes);

        /// <summary>
        /// Modifies dungeon translation nodes in a specific fashion to satisfy their connections while providing real tile mapping coordinates relative to the entrance.
        /// </summary>
        Dictionary<Guid, DungeonTranslationNode> Arrange(Dictionary<Guid, DungeonTranslationNode> nodes);
    }
}
