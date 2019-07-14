using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.Util.Math;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Generation.Dungeon;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using MagicalLifeMod.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.WorldGeneration.HallwayGenerators
{
    public class CircularHallwayGenerator : HallwayGenerator
    {
        public CircularHallwayGenerator()
        {
        }

        public override ProtoArray<Chunk> GenerateHallways(ProtoArray<Chunk> chunks, string dimensionName, Random random, Guid dimensionID)
        {
            chunks = this.GenerateStoneMap(chunks, dimensionID);

            int minElipseHallways = CoreSettingsHandler.DungeonGenerationConfig.Settings.MinCircleHallways;
            int maxElipseHallways = CoreSettingsHandler.DungeonGenerationConfig.Settings.MaxCircleHallways;

            int minElipseThickness = CoreSettingsHandler.DungeonGenerationConfig.Settings.MinCircleThickness;
            int maxElipseThickness = CoreSettingsHandler.DungeonGenerationConfig.Settings.MaxCircleThickness;

            int minElipseWidth = 15;
            int maxElipseWidth = 15 + (chunks.Width * 2);

            int minElipseHeight = 15;
            int maxElipseHeight = 15 + (chunks.Height * 2);

            int dimensionTileWidth = chunks.Width * Chunk.Width;
            int dimensionTileHeight = chunks.Height * Chunk.Height;

            int elipseHallways = random.Next(minElipseHallways, maxElipseHallways + 1);
            for (int i = 0; i < elipseHallways; i++)
            {
                int elipseThickness = random.Next(minElipseThickness, maxElipseThickness + 1);
                int elipseWidth = random.Next(minElipseWidth, maxElipseWidth);
                int elipseHeight = random.Next(minElipseHeight, maxElipseHeight);
                Point3D origin = this.GetRandomPoint(dimensionTileWidth, dimensionTileHeight, dimensionID, random);
                List<Point3D> elipseCoordinates = Geometry.GetPointsOnElipse(elipseWidth, elipseHeight, elipseThickness, dimensionID, dimensionTileWidth, dimensionTileHeight, origin);
                this.TurnToHallway(chunks, elipseCoordinates);
                MasterLog.DebugWriteLine("Generating elipse hallway: ");
                MasterLog.DebugWriteLine("Thickness: " + elipseThickness.ToString());
                MasterLog.DebugWriteLine("Width: " + elipseWidth.ToString());
                MasterLog.DebugWriteLine("Height: " + elipseHeight.ToString());
                MasterLog.DebugWriteLine("Origin: " + origin.ToString());
            }

            return chunks;
        }

        /// <summary>
        /// Converts the specified locations to hallway.
        /// </summary>
        private void TurnToHallway(ProtoArray<Chunk> chunks, List<Point3D> locations)
        {
            for (int i = 0; i < locations.Count; i++)
            {
                Point3D location = locations[i];
                int chunkX = location.X / Chunk.Width;
                int chunkY = location.Y / Chunk.Height;
                int tileX = location.X % Chunk.Width;
                int tileY = location.Y % Chunk.Height;

                Chunk chunk = chunks[chunkX, chunkY];
                Tile tile = chunk.Tiles[tileX, tileY];
                tile.MainObject = null;
            }
        }

        /// <summary>
        /// Gets a random point within the dimension.
        /// </summary>
        private Point3D GetRandomPoint(int dimensionTileWidth, int dimensionTileHeight, Guid dimensionID, Random random)
        {
            int x = random.Next(0, dimensionTileWidth);
            int y = random.Next(0, dimensionTileHeight);
            return new Point3D(x, y, dimensionID);
        }

        private ProtoArray<Chunk> GenerateStoneMap(ProtoArray<Chunk> chunks, Guid dimensionID)
        {
            for (int i = chunks.Data.Length - 1; i > -1; i--)
            {
                Chunk chunk = chunks.Data[i];
                chunk = this.GenerateStone(chunk, dimensionID);
            }

            return chunks;
        }

        private Chunk GenerateStone(Chunk chunk, Guid dimensionID)
        {
            int startingX = chunk.ChunkLocation.X * Chunk.Width;
            int startingY = chunk.ChunkLocation.Y * Chunk.Height;

            for (int x = 0; x < Chunk.Width; x++)
            {
                for (int y = 0; y < Chunk.Height; y++)
                {
                    int tileX = x + startingX;
                    int tileY = y + startingY;
                    Dirt dirt = new Dirt(new Point3D(tileX, tileY, dimensionID));
                    dirt.MainObject = new Rock(100);

                    chunk.Tiles[x, y] = dirt;
                }
            }

            return chunk;
        }
    }
}
