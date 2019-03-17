﻿using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Generation;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// All classes that implement <see cref="DimensionGenerator"/> control what generators are applied to which chunks.
    /// </summary>
    public abstract class DimensionGenerator
    {
        public Guid ID { get; }

        public readonly int Dimension;

        /// <summary>
        /// The seeded random number generator.
        /// </summary>
        public Random RNG;

        /// <summary>
        /// All registered terrain generators from the core game and mods.
        /// </summary>
        protected readonly List<TerrainGenerator> TerrainGenerators;

        /// <summary>
        /// All registered vegetation generators from the core game and mods.
        /// </summary>
        protected readonly List<VegetationGenerator> VegetationGenerators;

        /// <summary>
        /// All registered structure generators from the core game and mods.
        /// </summary>
        protected readonly List<StructureGenerator> StructureGenerators;

        /// <param name="dimension">The dimension that is being generated.</param>
        /// <param name="terrainGenerators">All registered terrain generators from the core game and mods.</param>
        /// <param name="vegetationGenerators">All registered vegetation generators from the core game and mods.</param>
        /// <param name="structureGenerators">All registered structure generators from the core game and mods.</param>
        /// <param name="random">This should be a seeded random number generator.</param>
        public DimensionGenerator()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Generates width * height chunks.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ProtoArray<Chunk> Generate(int width, int height, string dimensionName, Random r)
        {
            return this.GenerateWorld(this.GenerateBlank(width, height), dimensionName, r);
        }

        protected abstract ProtoArray<Chunk> GenerateWorld(ProtoArray<Chunk> blankWorld, string dimensionName, Random r);

        internal ProtoArray<Chunk> GenerateBlank(int chunkWidth, int chunkHeight)
        {
            ProtoArray<Chunk> blank = new ProtoArray<Chunk>(chunkWidth, chunkHeight);

            for (int x = 0; x < chunkWidth; x++)
            {
                for (int y = 0; y < chunkHeight; y++)
                {
                    blank[x, y] = new Chunk(
                        new Dictionary<Guid, Living>(), new ProtoArray<Tile>(Chunk.Width, Chunk.Height), new Point2D(x, y));
                }
            }

            return blank;
        }
    }
}