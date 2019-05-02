using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Resources;
using MagicalLifeAPI.World.Tiles;
using MagicalLifeMod.Core.Settings;
using System;

namespace MagicalLifeMod.Core.WorldGeneration.TerrainGenerators
{
    public class GrassTerrain : TerrainGenerator
    {
        public GrassTerrain(int dimension) : base(CoreSettingsHandler.GenerationSettings.Settings.GrassTerrainWeight, dimension)
        {
        }

        public override Chunk[] GenerateTerrain(Chunk[] blankChunks, string dimensionName, Random seededRandom)
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
                        chunk.Tiles[i, j] = this.GenerateTile(x, y, seededRandom);
                    }
                }
            }

            return blankChunks;
        }

        private Tile GenerateTile(int x, int y, Random seededRandom)
        {
            Grass dirt = new Grass(x, y, this.Dimension);

            if (seededRandom.Next(0, 5) == 3)
            {
                dirt.Resources = new Rock(seededRandom.Next(1, 170));
            }
            else
            {
                if (seededRandom.Next(0, 10) == 4)
                {
                    dirt.Resources = new MapleTree(100);
                }
            }

            return dirt;
        }
    }
}