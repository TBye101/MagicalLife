using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Generation.Dungeon
{
    /// <summary>
    /// Implementers of this generator populate empty rooms with objects, traps, etc...
    /// This step happens after hallways and empty rooms are generated. 
    /// </summary>
    public abstract class RoomDecorationGenerator
    {
        public abstract Chunk[] PopulateRoom(Chunk[] chunks, string dimensionName, Random random);
    }
}
