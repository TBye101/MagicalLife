using MagicalLifeAPI.World.Data;
using System;

namespace MagicalLifeAPI.World.Generation.Dungeon
{
    /// <summary>
    /// Implementers of this generate hallways for the dungeon.
    /// Hallways are generated before the rooms are generated. 
    /// </summary>
    public abstract class HallwayGenerator
    {
        public abstract Chunk[] GenerateHallways(Chunk[] chunks, string dimensionName, Random random, Guid dimensionID);
    }
}
