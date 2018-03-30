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
        public static Tile GetTileByID(Tile[,] tiles, string str)
        {
            int x = 0;
            int y = 0;

            string xstr = str;
            xstr = xstr.Replace("{X:", "");
            xstr = xstr.Replace(" Y:", ", ");
            xstr = xstr.Replace("}", "");

            string[] splits = xstr.Split(new string[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
            x = int.Parse(splits[0]);
            y = int.Parse(splits[1]);

            return tiles[x, y];
        }
    }
}