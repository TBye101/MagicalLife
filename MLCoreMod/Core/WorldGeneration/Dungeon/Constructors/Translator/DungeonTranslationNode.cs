using Microsoft.Xna.Framework;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator
{
    public class DungeonTranslationNode
    {
        public DungeonNode DNode { get; set; }

        public int? SectionWidth { get; set; }
        public int? SectionHeight { get; set; }

        /// <summary>
        /// The x offset of the top left point of this section from the entrance.
        /// </summary>
        public int? SectionXOffset { get; set; }

        /// <summary>
        /// The y offset of the top left point of this section from the entrance.
        /// </summary>
        public int? SectionYOffset { get; set; }

        public DungeonTranslationNode(DungeonNode dungeonNode)
        {
            this.DNode = dungeonNode;
        }
    }
}
