using System.Collections.Generic;
using MLAPI.DataTypes;
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

        /// <summary>
        /// Creates a room or hallway.
        /// </summary>
        void CreateRoomOrHallway(ProtoArray<Chunk> dungeonChunks, int x, int y, int width, int height);

        /// <summary>
        /// Connects all rooms that should be connected without overlapping.
        /// </summary>
        /// <param name="translatedNodes"></param>
        void ConnectRooms(ProtoArray<Chunk> dungeonChunks, List<DungeonTranslationNode> translatedNodes, Point2D entranceLocation);
    }
}