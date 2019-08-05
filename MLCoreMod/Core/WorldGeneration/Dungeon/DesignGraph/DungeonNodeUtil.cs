using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph
{
    public static class DungeonNodeUtil
    {
        /// <summary>
        /// Returns all discoverable dungeon nodes of a certain type.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IList<DungeonNode> GetAllRoomType(DungeonNode node, DungeonNodeType type)
        {
            List<DungeonNode> roomNodes = new List<DungeonNode>();
            HashSet<Guid> checkedNodes = new HashSet<Guid>();

            List<DungeonNode> toCheck = new List<DungeonNode>
            {
                node
            };

            while (toCheck.Count > 0)
            {
                DungeonNode toCheckNode = toCheck[0];
                checkedNodes.Add(toCheckNode.NodeId);
                toCheck.RemoveAt(0);
                if (toCheckNode.NodeType == type)
                {
                    roomNodes.Add(toCheckNode);
                }

                for (int i = 0; i < toCheckNode.Connections.Count; i++)
                {
                    DungeonNode connectionCheck = toCheckNode.Connections[i];
                    if (!checkedNodes.Contains(connectionCheck.NodeId))
                    {
                        toCheck.Add(connectionCheck);
                    }
                }
            }

            return roomNodes;
        }
    }
}
