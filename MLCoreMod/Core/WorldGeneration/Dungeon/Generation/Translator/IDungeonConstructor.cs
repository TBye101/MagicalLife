using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors
{
    /// <summary>
    /// Used to create dungeon tiles and empty rooms/hallways.
    /// </summary>
    public interface IDungeonConstructor
    {
        void Setup(ProtoArray<Chunk> dungeonChunks);
        void CreateRoomOrHallway(ProtoArray<Chunk> dungeonChunks, int x, int y, int width, int height);
    }
}