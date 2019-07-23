using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph
{
    /// <summary>
    /// Represents a node within the dungeon design graph.
    /// </summary>
    public struct DungeonNode
    {
        public DungeonNodeType NodeType { get; set; }

        public Guid NodeID { get; set; }

        public List<DungeonNode> Connections { get; set; }

        /// <param name="nodeNumber">The number of nodes in this dungeon design graph when this node was created.</param>
        public DungeonNode(DungeonNodeType nodeType)
        {
            this.NodeType = nodeType;
            this.Connections = new List<DungeonNode>();
            this.NodeID = Guid.NewGuid();
        }
    }
}