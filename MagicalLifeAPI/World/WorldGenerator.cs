using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// All classes that implement <see cref="DimensionGenerator"/> control how each biome is allocated space to be generated in, and which biome is to be generated where.
    /// </summary>
    public abstract class DimensionGenerator : Unique
    {
        /// <summary>
        /// Generates the world.
        /// </summary>
        /// <param name="chunkWidth">The width of the world in chunks.</param>
        /// <param name="chunkHeight">The height of the world in chunks.</param>
        /// <returns></returns>
        public ProtoArray<Chunk> GenerateWorld(int chunkWidth, int chunkHeight, Random random)
        {
            string[,] biomes = this.AssignBiomes(chunkWidth, chunkHeight, random);

            ProtoArray<Chunk> map = this.GenerateBlank(chunkWidth, chunkHeight, biomes);

            this.GenerateLandType(biomes, map, random);

            this.GenerateNaturalFeatures(map, random);
            this.GenerateMinerals(map, random);
            this.GenerateVegetation(map, random);
            this.GenerateStructures(map, random);
            this.GenerateDetails(map, random);

            return map;
        }

        internal ProtoArray<Chunk> GenerateBlank(int chunkWidth, int chunkHeight, string[,] biomes)
        {
            ProtoArray<Chunk> blank = new ProtoArray<Chunk>(chunkWidth, chunkHeight);

            for (int x = 0; x < chunkWidth; x++)
            {
                for (int y = 0; y < chunkHeight; y++)
                {
                    blank[x, y] = new Chunk(
                        new List<Living>(), new ProtoArray<Tile>(Chunk.Width, Chunk.Height), new Point(x, y), biomes[x, y]);
                }
            }

            return blank;
        }

        /// <summary>
        /// Populates the passed in array with the name of a biome for each tile.
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <param name="zSize"></param>
        /// <returns></returns>
        protected abstract string[,] AssignBiomes(int xSize, int ySize, Random random);

        /// <summary>
        /// Generates things such as dirt, grassland, and sand for each and every tile.
        /// </summary>
        /// <param name="biomeMap"></param>
        /// <returns></returns>
        protected abstract ProtoArray<Chunk> GenerateLandType(string[,] biomeMap, ProtoArray<Chunk> map, Random random);

        /// <summary>
        /// Generates things such as rivers and caves.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        protected abstract ProtoArray<Chunk> GenerateNaturalFeatures(ProtoArray<Chunk> map, Random random);

        /// <summary>
        /// Generates minerals in the world.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        protected abstract ProtoArray<Chunk> GenerateMinerals(ProtoArray<Chunk> map, Random random);

        /// <summary>
        /// Generates vegetation in the world.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        protected abstract ProtoArray<Chunk> GenerateVegetation(ProtoArray<Chunk> map, Random random);

        /// <summary>
        /// Generates structures in the world.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        protected abstract ProtoArray<Chunk> GenerateStructures(ProtoArray<Chunk> map, Random random);

        /// <summary>
        /// Generates any other details not done in previous phases.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        protected abstract ProtoArray<Chunk> GenerateDetails(ProtoArray<Chunk> map, Random random);
    }
}