using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator.ForceDirectedGraph
{
    public class ForceDirectedArranger : IDungeonGraphArranger
    {
        public ForceDirectedArranger()
        {
        }

        public Dictionary<Guid, DungeonTranslationNode> Arrange(Dictionary<Guid, DungeonTranslationNode> nodes)
        {
            return nodes;
        }
    }
}
