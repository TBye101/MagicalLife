using System;
using System.Collections.Generic;
using System.Text;
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
            DungeonNode entranceNode = new DungeonNode(DungeonNodeType.EntranceRoom);
        }
    }
}
