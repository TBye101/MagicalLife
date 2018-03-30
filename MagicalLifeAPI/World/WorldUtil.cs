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
            // {X:10 Y:4}
            //10   4
            int x = 0;
            int y = 0;

            string xstr = str;
            xstr = xstr.Substring(1);
            xstr.Replace('Y', ' ');
            xstr.Replace(':', ' ');
            xstr.Remove(xstr.IndexOf(' '), 2);
            string[] splits = xstr.Split(' ');
            x = int.Parse(splits[0]);
            y = int.Parse(splits[1]);

            //string xstr = str.Substring(str.IndexOf(':') + 1, str.IndexOf(' ') - 3);
            //string ystr = str.Substring(str.LastIndexOf(':') + 1, str.Length - str.LastIndexOf(':') - 1);
            //x = int.Parse(xstr);
            //y = int.Parse(ystr);

            return tiles[x, y];
        }
    }
}