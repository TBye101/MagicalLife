using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World.Base;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace MagicalLifeAPI.World
{
    public abstract class Tile : Unique
    {
        /// <summary>
        /// Initializes a new tile object.
        /// </summary>
        /// <param name="location">The 3D location of this tile in the map.</param>
        public Tile(Point3D location)
        {
            this.Location = location;
        }

        /// <summary>
        /// Returns the name of the biome that this tile belongs to.
        /// </summary>
        public string BiomeName { get; }

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
        public Queue<Living> Living { get; set; } = new Queue<Entities.Living>();
    }
}