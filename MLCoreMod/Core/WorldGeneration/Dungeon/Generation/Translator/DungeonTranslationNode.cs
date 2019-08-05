using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    public class DungeonTranslationNode
    {
        public DungeonNode DesignNode { get; set; }

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
            this.DesignNode = dungeonNode;
        }
    }
}
