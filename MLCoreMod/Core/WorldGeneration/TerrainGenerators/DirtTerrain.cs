using System;
using MLAPI.DataTypes;
using MLAPI.World.Base;
using MLAPI.World.Data;
using MLAPI.World.Generation;
using MLCoreMod.Core.Resources;
using MLCoreMod.Core.Settings;
using MLCoreMod.Core.Tiles;

namespace MLCoreMod.Core.WorldGeneration.TerrainGenerators
{
    public class DirtTerrain : TerrainGenerator
    {
        public DirtTerrain(int dimension) : base(CoreSettingsHandler.GenerationSettings.Settings.DirtTerrainWeight, dimension)
        {
        }

        public override Chunk[] GenerateTerrain(Chunk[] blankChunks, string dimensionName, Random seededRandom, Guid dimensionID)
        {
            foreach (Chunk chunk in blankChunks)
            {
                //Chunks have x and y chunk coordinates
                //We can use these to calculate the x and y of each tile
                for (int i = 0; i < Chunk.Width; i++)
                {
                    for (int j = 0; j < Chunk.Height; j++)
                    {
                        Point2D chunkLocation = chunk.ChunkLocation;
                        int x = (chunkLocation.X * Chunk.Width) + i;
                        int y = (chunkLocation.Y * Chunk.Height) + j;
                        chunk.Tiles[i, j] = this.GenerateTile(x, y, seededRandom, dimensionID);
                    }
                }
            }

            return blankChunks;
        }

        private Tile GenerateTile(int x, int y, Random seededRandom, Guid dimensionID)
        {
            Dirt dirt = new Dirt(x, y, dimensionID);

            if (seededRandom.Next(0, 5) == 3)
            {
                dirt.MainObject = new Rock(seededRandom.Next(1, 170));
            }

            return dirt;
        }
    }
}