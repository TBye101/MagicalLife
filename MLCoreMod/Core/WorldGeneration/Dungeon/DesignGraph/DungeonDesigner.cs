using MLAPI.Genetic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph
{
    /// <summary>
    /// Takes a chromosome of dungeon generation rules (RoomGenChance) and turns them into a dungeon design graph.
    /// </summary>
    public abstract class DungeonDesigner
    {
        public abstract DungeonNode GetDungeonDesign(Chromosome generationRules);
    }
}
