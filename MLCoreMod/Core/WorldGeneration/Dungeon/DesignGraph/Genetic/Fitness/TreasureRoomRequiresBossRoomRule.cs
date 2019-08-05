using System;
using System.Collections.Generic;
using System.Text;
using MLCoreMod.Core.Settings;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness
{
    public class TreasureRoomRequiresBossRoomRule : FitnessRule
    {
        public override double GetCurrentPoints(DungeonNode graphStart)
        {
            if (CoreSettingsHandler.DungeonGenerationConfig.Settings.TreasureRoomRequiresBossRoomRuleEnabled)
            {
                IList<DungeonNode> treasureRooms = DungeonNodeUtil.GetAllRoomType(graphStart, DungeonNodeType.TreasureRoom);

                double points = 0;

                for (int i = 0; i < treasureRooms.Count; i++)
                {
                    if (this.MeetsRule(treasureRooms[i]))
                    {
                        points++;
                    }
                }

                return points;
            }
            else
            {
                return 0;
            }
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
                IList<DungeonNode> treasureRooms = DungeonNodeUtil.GetAllRoomType(graphStart, DungeonNodeType.TreasureRoom);
                return treasureRooms.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
