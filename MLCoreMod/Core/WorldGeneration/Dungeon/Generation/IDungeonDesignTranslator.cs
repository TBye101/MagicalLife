using System;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation
{
    /// <summary>
    /// Used to translate a dungeon design into coordinate data for rooms and hallways.
    /// </summary>
    public interface IDungeonDesignTranslator
    {

        /// <param name="dungeonDesign"></param>
        /// <param name="exitLocation">The exit location of the dungeon. AKA the stairs back up.</param>
        /// <returns></returns>
        ProtoArray<Chunk> Translate(DungeonNode dungeonDesign, Point3D exitLocation, Guid dimensionId);
    }
}
