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
            HallwayGenerator hallwayGen = this.GetRandomItem<HallwayGenerator>(WorldGeneratorRegistry.HallwayGenerators);
            RoomGenerator roomGen = this.GetRandomItem<RoomGenerator>(WorldGeneratorRegistry.RoomGenerators);
            RoomDecorationGenerator roomDecorator = this.GetRandomItem<RoomDecorationGenerator>(WorldGeneratorRegistry.RoomDecorators);
            CreatureGenerator creatureGen = this.GetRandomItem<CreatureGenerator>(WorldGeneratorRegistry.CreatureGenerators);

            if (hallwayGen == null || roomGen == null || roomDecorator == null || creatureGen == null)
            {
                MasterLog.DebugWriteLine("A dungeon generation component was missing");
            }

            Chunk[] hallways = hallwayGen.GenerateHallways(blankWorld.Data, dimensionName, r, dimensionID);
            Chunk[] rooms = roomGen.GenerateEmptyRoom(hallways, dimensionName, r);
            Chunk[] decoratedRooms = roomDecorator.PopulateRoom(rooms, dimensionName, r);
            Chunk[] creaturesGenerated = creatureGen.GenerateCreatures(decoratedRooms, dimensionName, r);

            blankWorld.Data = creaturesGenerated;
            return blankWorld;
        }

        /// <summary>
        /// Gets a random item from the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private T GetRandomItem<T>(IList<T> items)
        {
            if (items.Count < 1)
            {
                return default;
            }
            else
            {
                int randomIndex = StaticRandom.Rand(0, items.Count);
                return items[randomIndex];
            }
        }
    }
}
