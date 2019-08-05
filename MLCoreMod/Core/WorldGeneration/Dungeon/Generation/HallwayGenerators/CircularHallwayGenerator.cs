using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Filing.Logging;
using MLAPI.Util.Math;
using MLAPI.World.Base;
using MLAPI.World.Data;
using MLAPI.World.Generation.Dungeon;
using MLCoreMod.Core.Resources;
using MLCoreMod.Core.Settings;
using MLCoreMod.Core.Tiles;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.HallwayGenerators
{
    public class CircularHallwayGenerator : HallwayGenerator
    {
        public CircularHallwayGenerator()
        {
        }

        public override ProtoArray<Chunk> GenerateHallways(ProtoArray<Chunk> chunks, string dimensionName, Random random, Guid dimensionId)
        {
            chunks = this.GenerateStoneMap(chunks, dimensionId);

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
                Point3D origin = this.GetRandomPoint(dimensionTileWidth, dimensionTileHeight, dimensionId, random);
                List<Point3D> elipseCoordinates = Geometry.GetPointsOnElipse(elipseWidth, elipseHeight, elipseThickness, dimensionId, dimensionTileWidth, dimensionTileHeight, origin);
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
        private Point3D GetRandomPoint(int dimensionTileWidth, int dimensionTileHeight, Guid dimensionId, Random random)
        {
            int x = random.Next(0, dimensionTileWidth);
            int y = random.Next(0, dimensionTileHeight);
            return new Point3D(x, y, dimensionId);
        }

        private ProtoArray<Chunk> GenerateStoneMap(ProtoArray<Chunk> chunks, Guid dimensionId)
        {
            for (int i = chunks.Data.Length - 1; i > -1; i--)
            {
                Chunk chunk = chunks.Data[i];
                chunk = this.GenerateStone(chunk, dimensionId);
            }

            return chunks;
        }

        private Chunk GenerateStone(Chunk chunk, Guid dimensionId)
        {
            int startingX = chunk.ChunkLocation.X * Chunk.Width;
            int startingY = chunk.ChunkLocation.Y * Chunk.Height;

            for (int x = 0; x < Chunk.Width; x++)
            {
                for (int y = 0; y < Chunk.Height; y++)
                {
                    int tileX = x + startingX;
                    int tileY = y + startingY;
                    Dirt dirt = new Dirt(new Point3D(tileX, tileY, dimensionId));
                    dirt.MainObject = new Rock(100);

                    chunk.Tiles[x, y] = dirt;
                }
            }

            return chunk;
        }
    }
}
