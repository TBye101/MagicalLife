using System.Drawing;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.World.Base;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;

namespace MagicalLifeAPI.World
{
    public abstract class Tile : Unique
    {
        ///// <summary>
        ///// The loss of movement by stepping on this tile.
        ///// </summary>
        //public double MovementCost
        //{
        //    get
        //    {
        //        return this.LastMovementCost;
        //    }
        //}

        ///// <summary>
        ///// The additional movement cost that the terrain of the tile adds to the total movement cost of moving here.
        ///// </summary>
        //protected double AdditionalMovementCost { get; set; }

        ///// <summary>
        ///// The last calculated movement cost of this tile.
        ///// </summary>
        //private double LastMovementCost { get; set; }

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

        ///// <summary>
        ///// Returns the last calculated value of the temperature of this tile.
        ///// </summary>
        //public double Temperature
        //{
        //    get
        //    {
        //        return this.LastTemperature;
        //    }
        //}

        ///// <summary>
        ///// The last calculated temperature value of this tile.
        ///// </summary>
        //private double LastTemperature { get; set; }

        /// <summary>
        /// The resources that can be found in this tile.
        /// </summary>
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public List<Vegetation> Plants { get; set; } = new List<Vegetation>();

        /// <summary>
        /// The location of this tile in the tilemap.
        /// </summary>
        public Point3D GetLocation { get; protected set; }
    }
}