using MagicalLifeAPI.Universal;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// All classes that implement <see cref="WorldGenerator"/> control how each biome is allocated space to be generated in, and which biome is to be generated where.
    /// </summary>
    public abstract class WorldGenerator : Unique
    {
        /// <summary>
        /// Populates the passed in array with the name of a biome for each tile.
        /// </summary>
        /// <returns></returns>
        public abstract string[,,] AssignBiomes(string[,,] biomeMap);

        /// <summary>
        /// Generates things such as rock, dirt, grassland, and sand for each and every tile.
        /// </summary>
        /// <param name="biomeMap"></param>
        /// <returns></returns>
        public abstract Tile[,,] GenerateLandType(string[,,] biomeMap);

        /// <summary>
        /// Generates things such as rivers and caves.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public abstract Tile[,,] GenerateNaturalFeatures(Tile[,,] map);

        /// <summary>
        /// Generates minerals in the world.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public abstract Tile[,,] GenerateMinerals(Tile[,,] map);

        /// <summary>
        /// Generates vegetation in the world.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public abstract Tile[,,] GenerateVegetation(Tile[,,] map);

        /// <summary>
        /// Generates any other details not done in previous phases.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public abstract Tile[,,] GenerateDetails(Tile[,,] map);
    }
}
