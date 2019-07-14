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

        /// <summary>
        /// The number of nodes away from the attached node. 
        /// </summary>
        public int NodeDistance { get; set; }

        public Guid NodeID { get; set; }

        public List<DungeonNode> Connections { get; set; }

        /// <param name="nodeNumber">The number of nodes in this dungeon design graph when this node was created.</param>
        public DungeonNode(DungeonNodeType nodeType, int nodeNumber)
        {
            this.NodeType = nodeType;
            this.Connections = new List<DungeonNode>();
            this.NodeDistance = nodeNumber;
            this.NodeID = Guid.NewGuid();
        }
    }
}