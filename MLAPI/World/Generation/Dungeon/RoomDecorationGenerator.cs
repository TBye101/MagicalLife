using System;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;

namespace MLAPI.World.Generation.Dungeon
{
    /// <summary>
    /// Implementers of this generator populate empty rooms with objects, traps, etc...
    /// This step happens after hallways and empty rooms are generated. 
    /// </summary>
    public abstract class RoomDecorationGenerator
    {
        public abstract ProtoArray<Chunk> PopulateRoom(ProtoArray<Chunk> chunks, string dimensionName, Random random);
    }
}
