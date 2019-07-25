using System;
using System.Collections.Generic;
using System.Text;
using MagicalLifeAPI.Util;
using MagicalLifeMod.Core.Settings;
using MLAPI.Genetic;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.DesignGenerators
{
    /// <summary>
    /// Uses the rules as specified by <see cref="RoomGenChance"/> objects within the chromomsome to generate a dungeon design.
    /// </summary>
    public class RoomGenChanceDesignGenerator : DungeonDesigner
    {
        public RoomGenChanceDesignGenerator()
        {
        }

        public override DungeonNode GetDungeonDesign(Chromosome generationRules)
        {
            RoomGenChance[] dungeonGenRules = Array.ConvertAll(generationRules.Genes, item => (RoomGenChance)item.Value);

            int minRoomsOnNode = CoreSettingsHandler.DungeonGenerationConfig.Settings.MinRoomsAdjacentToNode;
            int maxRoomsOnNode = CoreSettingsHandler.DungeonGenerationConfig.Settings.MaxRoomsAdjacentToNode;
            int maxRoomsInDungeon = CoreSettingsHandler.DungeonGenerationConfig.Settings.MaxRoomsInDungeon;

            DungeonNode entranceNode = new DungeonNode(DungeonNodeType.EntranceRoom);

            int roomsGenerated = 1;

            List<DungeonNode> toRunRulesOn = new List<DungeonNode>();
            toRunRulesOn.Add(entranceNode);

            while(roomsGenerated < maxRoomsInDungeon && toRunRulesOn.Count > 0)
            {
                //Generate on node
                DungeonNode node = toRunRulesOn[0];
                toRunRulesOn.RemoveAt(0);
                if (this.CanAnyRoomGenerateOn(node, dungeonGenRules))
                {
                    int roomsToGenerate = StaticRandom.Rand(minRoomsOnNode, maxRoomsOnNode);
                    List<DungeonNode> connections = this.GenerateAdjacentRooms(node, roomsToGenerate, dungeonGenRules);
                    roomsGenerated += connections.Count;
                    toRunRulesOn.AddRange(connections);
                    node.Connections.AddRange(connections);
                }
            }

            return entranceNode;
        }

        private bool CanAnyRoomGenerateOn(DungeonNode node, RoomGenChance[] dungeonGenRules)
        {
            for (int i = 0; i < dungeonGenRules.Length; i++)
            {
                RoomGenChance genRule = dungeonGenRules[i];

                if (genRule.RoomTypeToGenerateOn == node.NodeType && genRule.ChanceToGenerate > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private List<DungeonNode> GenerateAdjacentRooms(DungeonNode node, int roomsToGenerate, RoomGenChance[] genRules)
        {
            int roomsGenerated = 0;
            List<DungeonNode> connections = new List<DungeonNode>();

            while (roomsGenerated < roomsToGenerate)
            {
                for (int i = 0; i < genRules.Length; i++)
                {
                    RoomGenChance genRule = genRules[i];

                    double chance = StaticRandom.Rand(0, 1);
                    if (chance < genRule.ChanceToGenerate)
                    {
                        DungeonNode newNode = new DungeonNode(genRule.RoomTypeToGenerate);
                        connections.Add(newNode);
                        roomsGenerated++;
                    }

                    if (roomsGenerated >= roomsToGenerate)
                    {
                        break;
                    }
                }
            }

            return connections;
        }
    }
}
