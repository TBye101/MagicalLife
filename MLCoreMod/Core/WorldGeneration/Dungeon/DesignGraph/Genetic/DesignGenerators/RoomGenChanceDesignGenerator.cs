using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Genetic;
using MLAPI.Util.RandomUtils;
using MLCoreMod.Core.Settings;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.DesignRules;

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
                    List<RoomGenChance> applicableRules = this.GetValidRules(node, dungeonGenRules);
                    NonDuplicateElementSelector<RoomGenChance> randomGenChanceSelector = new NonDuplicateElementSelector<RoomGenChance>(applicableRules);
                    int roomsToGenerate = StaticRandom.Rand(minRoomsOnNode, maxRoomsOnNode);
                    List<DungeonNode> connections = this.GenerateAdjacentRooms(node, roomsToGenerate, randomGenChanceSelector);
                    roomsGenerated += connections.Count;
                    toRunRulesOn.AddRange(connections);
                    node.Connections.AddRange(connections);
                }
            }

            return entranceNode;
        }

        /// <summary>
        /// Gets the rules that apply to the specified node type.
        /// </summary>
        /// <returns></returns>
        private List<RoomGenChance> GetValidRules(DungeonNode node, RoomGenChance[] genRules)
        {
            List<RoomGenChance> chances = new List<RoomGenChance>();

            for (int i = 0; i < genRules.Length; i++)
            {
                RoomGenChance chance = genRules[i];
                if (chance.RoomTypeToGenerateOn == node.NodeType)
                {
                    chances.Add(chance);
                }
            }

            return chances;
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

        private List<DungeonNode> GenerateAdjacentRooms(DungeonNode node, int roomsToGenerate, NonDuplicateElementSelector<RoomGenChance> genChancePicker)
        {
            int roomsGenerated = 0;
            List<DungeonNode> connections = new List<DungeonNode>();


            while (roomsGenerated < roomsToGenerate)
            {
                if (genChancePicker.ElementLeft < 1)
                {
                    genChancePicker.Reset();
                }

                RoomGenChance genRule = genChancePicker.GetRandomElement();

                double chance = StaticRandom.Rand(0F, 1F);
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

            return connections;
        }
    }
}
