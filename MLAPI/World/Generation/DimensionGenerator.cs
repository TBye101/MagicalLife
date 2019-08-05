using System;
using MLAPI.DataTypes.Collection;
using MLAPI.World.Data;

namespace MLAPI.World.Generation
{
    /// <summary>
    /// All classes that implement <see cref="DimensionGenerator"/> control what generators are applied to which chunks.
    /// </summary>
    public abstract class DimensionGenerator
    {
        public Guid Id { get; }

        protected DimensionGenerator()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Generates width * height chunks.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ProtoArray<Chunk> Generate(int width, int height, string dimensionName, Random r, Guid dimensionId)
        {
            return this.GenerateWorld(WorldUtil.GenerateBlankChunks(width, height), dimensionName, r, dimensionId);
        }

        protected abstract ProtoArray<Chunk> GenerateWorld(ProtoArray<Chunk> blankWorld, string dimensionName, Random r, Guid dimensionId);
    }
}