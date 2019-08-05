using System;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;

namespace MLAPI.World.Generation.Dungeon
{
    /// <summary>
    /// Implementers of this populate enemies and non-enemy creatures in the dungeon.
    /// This step happens after hallways and rooms are generated. 
    /// </summary>
    public abstract class CreatureGenerator
    {
        public abstract ProtoArray<Chunk> GenerateCreatures(ProtoArray<Chunk> chunks, string dimensionName, Random random);
    }
}
