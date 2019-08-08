using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Filing.Logging;
using MLAPI.Util.RandomUtils;
using MLAPI.World;
using MLAPI.World.Data;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;
using MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator.ForceDirectedGraph;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
{
    /// <summary>
    /// Lays out rooms and hallways, and then fills them through random assignment of room generators and other features.
    /// </summary>
    public class DefaultTranslator : IDungeonDesignTranslator
    {
        public ProtoArray<Chunk> Translate(DungeonNode dungeonDesign, Point3D exitLocation)
        {
            //Figure out sizes and offsets...
            //https://en.wikipedia.org/wiki/Force-directed_graph_drawing
            //Use a physics simulation to arrange them with attracting and repulsing forces
            List<DungeonTranslationNode> translatedNodes = CreateTranslationNodes(dungeonDesign);

            //Run simulation
            IDungeonGraphArranger arranger = new PhysicsDirectedArranger();
            arranger.Setup(translatedNodes);
            translatedNodes = arranger.Arrange(translatedNodes);

            //Convert coordinates to real tiles
            IDungeonConstructor constructor = new DefaultDungeonConstructor();

            DungeonTranslationNode entranceNode = translatedNodes.Find(x => x.DesignNode.NodeId.Equals(dungeonDesign.NodeId));
            Point2D dungeonSizeNeeded = CalculateDungeonSize(translatedNodes);
            ProtoArray<Chunk> dungeonChunks = WorldUtil.GenerateBlankChunks(dungeonSizeNeeded.X, dungeonSizeNeeded.Y);

            constructor.Setup(dungeonChunks);
            Point2D entranceLocation = CalculateEntranceLocation(entranceNode, translatedNodes);

            foreach (DungeonTranslationNode item in translatedNodes)
            {
                int x = item.Offset.X + entranceLocation.X;
                int y = item.Offset.Y + entranceLocation.Y;
                int width = item.SectionWidth;
                int height = item.SectionHeight;
                MasterLog.DebugWriteLine("Making room/hallway: ");
                var debugInfo = new {x, y, width, height};
                MasterLog.DebugWriteParams(debugInfo);
                constructor.CreateRoomOrHallway(dungeonChunks, x, y, width, height);
            }

            //Fill rooms and hallways with content from generators

            return dungeonChunks;
        }

        private static Point2D CalculateEntranceLocation(DungeonTranslationNode entranceNode, List<DungeonTranslationNode> translatedNodes)
        {
            GraphBounds graphBounds = CalculateGraphBounds(translatedNodes);

            Point2D entranceLocation = new Point2D(0, 0);

            if (graphBounds.LowestXPosition < 0)
            {
                entranceLocation.X = -1 * graphBounds.LowestXPosition;
            }

            if (graphBounds.LowestYPosition < 0)
            {
                entranceLocation.Y = -1 * graphBounds.LowestYPosition;
            }

            return entranceLocation;
        }

        /// <summary>
        /// Calculates the furthest spread of nodes in the graph.
        /// </summary>
        /// <param name="translatedNodes"></param>
        /// <returns></returns>
        private static GraphBounds CalculateGraphBounds(List<DungeonTranslationNode> translatedNodes)
        {
            GraphBounds bounds = new GraphBounds();

            foreach (DungeonTranslationNode item in translatedNodes)
            {
                int xPosition = item.Offset.X;
                int yPosition = item.Offset.Y;

                bounds.LowestXPosition = Math.Min(bounds.LowestXPosition, xPosition);
                bounds.HighestXPosition = Math.Max(bounds.HighestXPosition, xPosition);
                bounds.LowestYPosition = Math.Min(bounds.LowestYPosition, yPosition);
                bounds.HighestYPosition = Math.Max(bounds.HighestYPosition, yPosition);
            }

            return bounds;
        }

        /// <summary>
        /// Calculates the size requirements for the dungeon in chunks.
        /// </summary>
        /// <param name="translatedNodes"></param>
        /// <returns></returns>
        private static Point2D CalculateDungeonSize(List<DungeonTranslationNode> translatedNodes)
        {
            GraphBounds graphBounds = CalculateGraphBounds(translatedNodes);

            int tileWidth = graphBounds.HighestXPosition - graphBounds.LowestXPosition;
            int tileHeight = graphBounds.HighestYPosition - graphBounds.LowestYPosition;
            int chunkWidth = (tileWidth / Chunk.Width) + 1;
            int chunkHeight = (tileHeight / Chunk.Height) + 1;

            return new Point2D(chunkWidth, chunkHeight);
        }

        /// <summary>
        /// Generates translation nodes for the entire dungeon design.
        /// </summary>
        /// <param name="dungeonDesign"></param>
        /// <returns></returns>
        private static List<DungeonTranslationNode> CreateTranslationNodes(DungeonNode dungeonDesign)
        {
            List<DungeonTranslationNode> ret = new List<DungeonTranslationNode>();
            List<DungeonNode> toConvert = new List<DungeonNode>
            {
                dungeonDesign
            };

            while (toConvert.Count > 0)
            {
                DungeonNode node = toConvert[0];
                toConvert.RemoveAt(0);

                DungeonTranslationNode translatedNode = new DungeonTranslationNode(node)
                {
                    SectionHeight = StaticRandom.Rand(6, 20),
                    SectionWidth = StaticRandom.Rand(6, 20),
                    Offset = new Point2D(0, 0)
                };

                //Randomize initial node height and width.
                translatedNode.Offset = new Point2D(0, 0);

                ret.Add(translatedNode);

                for (int i = 0; i < node.Connections.Count; i++)
                {
                    DungeonNode connectedNode = node.Connections[i];

                    if (!ret.Exists(x => x.DesignNode.NodeId.Equals(connectedNode.NodeId)))
                    {
                        toConvert.Add(connectedNode);
                    }
                }
            }

            return ret;
        }
    }
}
