using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
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

        protected DimensionGenerator()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Generates width * height chunks.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ProtoArray<Chunk> Generate(int width, int height, string dimensionName, Random r, Guid dimensionID)
        {
            return this.GenerateWorld(WorldUtil.GenerateBlankChunks(width, height), dimensionName, r, dimensionID);
        }

        protected abstract ProtoArray<Chunk> GenerateWorld(ProtoArray<Chunk> blankWorld, string dimensionName, Random r, Guid dimensionID);
    }
}