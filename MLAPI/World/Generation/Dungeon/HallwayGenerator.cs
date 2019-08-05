using System;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;

namespace MLAPI.World.Generation.Dungeon
{
    /// <summary>
    /// Implementers of this generate hallways for the dungeon.
    /// Hallways are generated before the rooms are generated. 
    /// </summary>
    public abstract class HallwayGenerator
    {
        public abstract ProtoArray<Chunk> GenerateHallways(ProtoArray<Chunk> chunks, string dimensionName, Random random, Guid dimensionID);
    }
}
