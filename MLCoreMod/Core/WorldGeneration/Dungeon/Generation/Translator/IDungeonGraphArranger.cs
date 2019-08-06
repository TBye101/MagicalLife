using System;
using System.Collections.Generic;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    /// <summary>
    /// Used to modify dungeon translation nodes in a specific fashion to satisfy their connections while providing real tile mapping coordinates relative to the entrance.
    /// </summary>
    public interface IDungeonGraphArranger
    {
        void Setup(List<DungeonTranslationNode> nodes);

        /// <summary>
        /// Modifies dungeon translation nodes in a specific fashion to satisfy their connections while providing real tile mapping coordinates relative to the entrance.
        /// </summary>
        List<DungeonTranslationNode> Arrange(List<DungeonTranslationNode> nodes);
    }
}
