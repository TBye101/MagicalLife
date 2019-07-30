using System;
using System.Collections.Generic;
using System.Text;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;
using MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors
{
    /// <summary>
    /// Lays out rooms and hallways, and then fills them through random assignment of room generators and other features.
    /// </summary>
    class DefaultTranslator : IDungeonDesignTranslator
    {
        public ProtoArray<Chunk> Translate(DungeonNode dungeonDesign, Point3D exitLocation)
        {
            Dictionary<Guid, DungeonTranslationNode> translatedNodes = this.CreateTranslationNodes(dungeonDesign);
            //Figure out sizes and offsets...

            return null;
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
                ret.Add(translatedNode.DNode.NodeID, translatedNode);

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
