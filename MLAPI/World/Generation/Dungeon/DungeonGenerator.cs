using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// All classes that implement <see cref="DungeonGenerator"/> control what generators are applied to which chunks.
    /// </summary>
    public abstract class DungeonGenerator
    {
        public Guid ID { get; }

        protected DungeonGenerator()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Generates width * height chunks.
        /// </summary>
        /// <param name="exitLocation">The location within the dungeon of the dungeon stairs.</param>
        /// <param name="entranceLocation">The location outside of the dungeon that leads into the dungeon.</param>
        /// <returns></returns>
        public ProtoArray<Chunk> Generate(int width, int height, string dimensionName, Random r, Guid dimensionID, Point3D exitLocation, Point3D entranceLocation)
        {
            return this.GenerateDungeon(this.GenerateBlank(width, height), dimensionName, r, dimensionID, exitLocation, entranceLocation);
        }

        protected abstract ProtoArray<Chunk> GenerateDungeon(ProtoArray<Chunk> blankWorld, string dimensionName, Random r, Guid dimensionID, Point3D exitLocation, Point3D entranceLocation);

        private ProtoArray<Chunk> GenerateBlank(int chunkWidth, int chunkHeight)
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