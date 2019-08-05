using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator
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