using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.WorldGeneration;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Generation.Dungeon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.WorldGeneration.Default
{
    /// <summary>
    /// The default dungeon generator engine.
    /// </summary>
    public class DefaultDungeonGenerator : DungeonGenerator
    {
        public DefaultDungeonGenerator()
        {
        }

        protected override ProtoArray<Chunk> GenerateDungeon(ProtoArray<Chunk> blankWorld, string dimensionName, Random r, Guid dimensionID)
        {
            HallwayGenerator hallwayGen = WorldGeneratorRegistry.HallwayGenerators.GetRandomItem();
            RoomGenerator roomGen = WorldGeneratorRegistry.RoomGenerators.GetRandomItem();
            RoomDecorationGenerator roomDecorator = WorldGeneratorRegistry.RoomDecorators.GetRandomItem();
            CreatureGenerator creatureGen = WorldGeneratorRegistry.CreatureGenerators.GetRandomItem();

            if (hallwayGen == null || roomGen == null || roomDecorator == null || creatureGen == null)
            {
                MasterLog.DebugWriteLine("A dungeon generation component was missing");
            }

            ProtoArray<Chunk> hallways = hallwayGen.GenerateHallways(blankWorld, dimensionName, r, dimensionID);
            ProtoArray<Chunk> rooms = roomGen.GenerateEmptyRoom(hallways, dimensionName, r);
            ProtoArray<Chunk> decoratedRooms = roomDecorator.PopulateRoom(rooms, dimensionName, r);
            ProtoArray<Chunk> creaturesGenerated = creatureGen.GenerateCreatures(decoratedRooms, dimensionName, r);

            return creaturesGenerated;
        }
    }
}
