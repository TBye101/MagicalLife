using MagicalLifeMod.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness
{
    public class TreasureRoomRequiresBossRoomRule : FitnessRule
    {
        public override double GetCurrentPoints(DungeonNode graphStart)
        {
            DungeonNode[] treasureRooms = this.GetTreasureRooms(graphStart);

            double points = 0;

            for (int i = 0; i < treasureRooms.Length; i++)
            {
                if (this.MeetsRule(treasureRooms[i]))
                {
                    points++;
                }
            }

            return points;
        }

        private bool MeetsRule(DungeonNode treasureRoom)
        {
            for (int i = 0; i < treasureRoom.Connections.Count; i++)
            {
                DungeonNode connectedNode = treasureRoom.Connections[i];
                if (connectedNode.NodeType == DungeonNodeType.BossRoom)
                {
                    return true;
                }
            }

            return false;
        }

        public override double GetTotalPoints(DungeonNode graphStart)
        {
            if (CoreSettingsHandler.DungeonGenerationConfig.Settings.TreasureRoomRequiresBossRoomRuleEnabled)
            {
                DungeonNode[] treasureRooms = this.GetTreasureRooms(graphStart);
                return treasureRooms.Length;
            }
            else
            {
                return 0;
            }
        }

        private DungeonNode[] GetTreasureRooms(DungeonNode node)
        {
            List<DungeonNode> treasureNodes = new List<DungeonNode>();
            HashSet<Guid> checkedNodes = new HashSet<Guid>();

            List<DungeonNode> toCheck = new List<DungeonNode>
            {
                node
            };

            while (toCheck.Count > 0)
            {
                DungeonNode toCheckNode = toCheck[0];
                checkedNodes.Add(toCheckNode.NodeID);
                toCheck.RemoveAt(0);
                if (toCheckNode.NodeType == DungeonNodeType.TreasureRoom)
                {
                    treasureNodes.Add(toCheckNode);
                }

                for (int i = 0; i < toCheckNode.Connections.Count; i++)
                {
                    DungeonNode connectionCheck = toCheckNode.Connections[i];
                    if (!checkedNodes.Contains(connectionCheck.NodeID))
                    {
                        toCheck.Add(connectionCheck);
                    }
                }
            }

            return treasureNodes.ToArray();
        }
    }
}
