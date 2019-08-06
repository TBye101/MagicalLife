using System.Collections;
using MLAPI.DataTypes;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    public class DungeonTranslationNode : IEnumerable
    {
        public DungeonNode DesignNode { get; set; }

        public int SectionWidth { get; set; }
        public int SectionHeight { get; set; }

        public Point2D Offset { get; set; }

        public DungeonTranslationNode(DungeonNode dungeonNode)
        {
            this.DesignNode = dungeonNode;
            this.Offset = Point2D.Zero;

        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
