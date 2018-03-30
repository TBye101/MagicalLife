using MagicalLifeAPI.DataTypes;
using System.Diagnostics;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Holds some utilities for world stuff.
    /// </summary>
    public static class WorldUtil
    {
        /// <summary>
        /// Returns a tile based on it's location in string format.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="tiles"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Tile GetTileByID(Tile[,,] tiles, string str)
        {
            Point3D point = new Point3D(str);
            return tiles[point.X, point.Y, point.Z];
        }
    }
}