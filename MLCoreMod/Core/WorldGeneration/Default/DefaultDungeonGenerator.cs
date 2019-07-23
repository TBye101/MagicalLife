using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.WorldGeneration;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Generation.Dungeon;
using MagicalLifeMod.Core.GameStructures.Parts;
using MLAPI.Genetic;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.DesignGenerators;
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

        protected override ProtoArray<Chunk> GenerateDungeon(ProtoArray<Chunk> blankWorld, string dimensionName, Random r, Guid dimensionID, Point3D exitLocation, Point3D entranceLocation)
        {
            DungeonDesignRuleGenerator geneticDesigner = new DungeonDesignRuleGenerator();
            DungeonDesigner designer = new RoomGenChanceDesignGenerator();
            Chromosome dungeonDesignRules = geneticDesigner.AdaptDungeonDesignRules();
            DungeonNode dungeonDesign = designer.GetDungeonDesign(dungeonDesignRules);

            HallwayGenerator hallwayGen = WorldGeneratorRegistry.HallwayGenerators.GetRandomItem();
            RoomGenerator roomGen = WorldGeneratorRegistry.RoomGenerators.GetRandomItem();
            RoomDecorationGenerator roomDecorator = WorldGeneratorRegistry.RoomDecorators.GetRandomItem();
            CreatureGenerator creatureGen = WorldGeneratorRegistry.CreatureGenerators.GetRandomItem();

            if (hallwayGen == null || roomGen == null || roomDecorator == null || creatureGen == null)
            {
                MasterLog.DebugWriteLine("A dungeon generation component was missing");
            }

            ProtoArray<Chunk> hallways = hallwayGen.GenerateHallways(blankWorld, dimensionName, r, dimensionID);
            //ProtoArray<Chunk> rooms = roomGen.GenerateEmptyRoom(hallways, dimensionName, r);
            //ProtoArray<Chunk> decoratedRooms = roomDecorator.PopulateRoom(rooms, dimensionName, r);
            //ProtoArray<Chunk> creaturesGenerated = creatureGen.GenerateCreatures(decoratedRooms, dimensionName, r);

            int chunkX = exitLocation.X / Chunk.Width;
            int chunkY = exitLocation.Y / Chunk.Height;
            int tileX = exitLocation.X % Chunk.Width;
            int tileY = exitLocation.Y % Chunk.Height;
            Chunk chunk = hallways[chunkX, chunkY];
            Tile entranceTile = chunk.Tiles[tileX, tileY];
            entranceTile.MainObject = new DungeonStairDown(Guid.NewGuid(), entranceLocation);

            //return creaturesGenerated;
            return hallways;
        }
    }
}
