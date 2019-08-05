using System;
using System.Collections.Generic;
using System.Text;
using MLCoreMod.Core.Settings;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness
{
    /// <summary>
    /// Disallows boss rooms from being adjacent.
    /// </summary>
    public class NoConnectedBossRoomsRule : FitnessRule
    {
        public NoConnectedBossRoomsRule()
        {
        }

        public override double GetCurrentPoints(DungeonNode graphStart)
        {
            if (CoreSettingsHandler.DungeonGenerationConfig.Settings.NoConnectedBossRoomsRuleEnabled)
            {
                IList<DungeonNode> bossNodes = DungeonNodeUtil.GetAllRoomType(graphStart, DungeonNodeType.BossRoom);
                double acceptableBossRooms = 0;

                for (int i = 0; i < bossNodes.Count; i++)
                {
                    DungeonNode node = bossNodes[i];

                    if (this.MeetsRule(node))
                    {
                        acceptableBossRooms++;
                    }
                }

                return acceptableBossRooms;
            }
            else
            {
                return 0;
            }
        }

        public override double GetTotalPoints(DungeonNode graphStart)
        {
            if (CoreSettingsHandler.DungeonGenerationConfig.Settings.NoConnectedBossRoomsRuleEnabled)
            {
                IList<DungeonNode> bossNodes = DungeonNodeUtil.GetAllRoomType(graphStart, DungeonNodeType.BossRoom);
                return bossNodes.Count;
            }
            else
            {
                return 0;
            }
        }

        private bool MeetsRule(DungeonNode node)
        {
            for (int i = 0; i < node.Connections.Count; i++)
            {
                DungeonNode connection = node.Connections[i];
                if (connection.NodeType == DungeonNodeType.BossRoom)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
