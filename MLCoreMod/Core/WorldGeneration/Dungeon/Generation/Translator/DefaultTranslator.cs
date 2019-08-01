using System;
using System.Collections.Generic;
using System.Text;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using Microsoft.Xna.Framework;
using MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator;
using MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator.ForceDirectedGraph;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;
using MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors
{
    /// <summary>
    /// Lays out rooms and hallways, and then fills them through random assignment of room generators and other features.
    /// </summary>
    class DefaultTranslator : IDungeonDesignTranslator
    {
        public ProtoArray<Chunk> Translate(DungeonNode dungeonDesign, Point3D exitLocation)
        {
            //Figure out sizes and offsets...
            //https://en.wikipedia.org/wiki/Force-directed_graph_drawing
            //Use a physics simulation to arrange them with attracting and repulsing forces
            Dictionary<Guid, DungeonTranslationNode> translatedNodes = this.CreateTranslationNodes(dungeonDesign);

            //Run simulation
            IDungeonGraphArranger arranger = new ForceDirectedArranger();
            translatedNodes = arranger.Arrange(translatedNodes);

            //Convert coordinates to real tiles
            IDungeonConstructor constructor = new DefaultDungeonConstructor();

            DungeonTranslationNode entranceNode = translatedNodes[dungeonDesign.NodeID];
            Point2D dungeonSizeNeeded = this.CalculateDungeonSize(translatedNodes);
            ProtoArray<Chunk> dungeonChunks = WorldUtil.GenerateBlankChunks(dungeonSizeNeeded.X, dungeonSizeNeeded.Y);

            constructor.Setup(dungeonChunks);

            foreach (KeyValuePair<Guid, DungeonTranslationNode> item in translatedNodes)
            {
                int x = item.Value.SectionXOffset.Value + entranceNode.SectionXOffset.Value;
                int y = item.Value.SectionYOffset.Value + entranceNode.SectionYOffset.Value;
                int width = item.Value.SectionWidth.Value;
                int height = item.Value.SectionHeight.Value;
                constructor.CreateRoomOrHallway(dungeonChunks, x, y, width, height);
            }

            //Fill rooms and hallways with content from generators

            return dungeonChunks;
        }

        /// <summary>
        /// Calculates the size requirements for the dungeon in chunks.
        /// </summary>
        /// <param name="translatedNodes"></param>
        /// <returns></returns>
        private Point2D CalculateDungeonSize(Dictionary<Guid, DungeonTranslationNode> translatedNodes)
        {
            int lowestXPosition = 0;
            int highestXPosition = 0;
            int lowestYPosition = 0;
            int highestYPosition = 0;

            foreach (KeyValuePair<Guid, DungeonTranslationNode> item in translatedNodes)
            {
                int xPosition = item.Value.SectionXOffset.Value + item.Value.SectionWidth.Value;
                int yPosition = item.Value.SectionYOffset.Value + item.Value.SectionHeight.Value;

                lowestXPosition = Math.Min(lowestXPosition, xPosition);
                highestXPosition = Math.Max(highestXPosition, xPosition);
                lowestYPosition = Math.Min(lowestYPosition, yPosition);
                highestYPosition = Math.Max(highestYPosition, yPosition);
            }

            int tileWidth = highestXPosition - lowestXPosition;
            int tileHeight = highestYPosition - lowestYPosition;
            int chunkWidth = (tileWidth / Chunk.Width) + 1;
            int chunkHeight = (tileHeight / Chunk.Height) + 1;

            return new Point2D(chunkWidth, chunkHeight);
        }

        /// <summary>
        /// Generates translation nodes for the entire dungeon design.
        /// </summary>
        /// <param name="dungeonDesign"></param>
        /// <returns></returns>
        private Dictionary<Guid, DungeonTranslationNode> CreateTranslationNodes(DungeonNode dungeonDesign)
        {
            Dictionary<Guid, DungeonTranslationNode> ret = new Dictionary<Guid, DungeonTranslationNode>();
            List<DungeonNode> toConvert = new List<DungeonNode>
            {
                dungeonDesign
            };

            while (toConvert.Count > 0)
            {
                DungeonNode node = toConvert[0];
                toConvert.RemoveAt(0);

                DungeonTranslationNode translatedNode = new DungeonTranslationNode(node);

                //Randomize initial node height and width.
                translatedNode.SectionHeight = StaticRandom.Rand(6, 20);
                translatedNode.SectionWidth = StaticRandom.Rand(6, 20);
                translatedNode.SectionXOffset = 0;
                translatedNode.SectionYOffset = 0;

                ret.Add(translatedNode.DesignNode.NodeID, translatedNode);

                for (int i = 0; i < node.Connections.Count; i++)
                {
                    DungeonNode connectedNode = node.Connections[i];

                    if (!ret.ContainsKey(connectedNode.NodeID))
                    {
                        toConvert.Add(connectedNode);
                    }
                }
            }

            return ret;
        }
    }
}
