using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World.Base;
using System.Collections.Generic;
using System.Drawing;

namespace MagicalLifeAPI.World
{
    public abstract class Tile : Unique
    {
        /// <summary>
        /// Initializes a new tile object.
        /// </summary>
        /// <param name="location">The 3D location of this tile in the map.</param>
        /// <param name="movementCost">This value is the movement cost of walking on this tile. It should be between 1 and 100</param>
        public Tile(Point3D location, int movementCost)
        {
            this.Location = location;
            this.MovementCost = movementCost;
        }

        /// <summary>
        /// Returns the name of the biome that this tile belongs to.
        /// </summary>
        public string BiomeName { get; }

        /// <summary>
        /// Returns the movement cost of this tile.
        /// Should be between 1-100.
        /// </summary>
        public int MovementCost { get; protected set; }

        /// <summary>
        /// The size, in pixels of how big each tile is.
        /// </summary>
        /// <returns></returns>
        public static Size GetTileSize()
        {
            return new Size(64, 64);
        }

        /// <summary>
        /// Returns the name of this tile.
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// Returns the name of the texture used by this tile, including the file extension.
        /// </summary>
        /// <returns></returns>
        public abstract string GetTextureName();

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public List<Vegetation> Plants { get; set; } = new List<Vegetation>();

        /// <summary>
        /// The location of this tile in the tilemap.
        /// </summary>
        public Point3D Location { get; protected set; }

        /// <summary>
        /// A list containing all living entities on this tile.
        /// </summary>
        public List<Living> Living { get; set; } = new List<Entities.Living>();
    }
}