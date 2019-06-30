using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Generation.Dungeon
{
    /// <summary>
    /// Implementers of this populate enemies and non-enemy creatures in the dungeon.
    /// This step happens after hallways and rooms are generated. 
    /// </summary>
    public abstract class CreatureGenerator
    {
        public abstract Chunk[] GenerateCreatures(Chunk[] chunks, string dimensionName, Random random);
    }
}
