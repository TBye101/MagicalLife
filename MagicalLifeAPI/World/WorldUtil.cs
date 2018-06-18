using MagicalLifeAPI.DataTypes;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
        public static Tile GetTileByID(ProtoArray<Tile> tiles, string str)
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

        /// <summary>
        /// Returns all the tiles that neighbor the specified tile.
        /// </summary>
        /// <returns></returns>
        public static List<Point> GetNeighboringTiles(Point tileLocation, int dimension)
        {
            List<Point> neighborCandidates = new List<Point>();
            List<Point> neighbors = new List<Point>();

            neighborCandidates.Add(new Point(tileLocation.X + 1, tileLocation.Y));
            neighborCandidates.Add(new Point(tileLocation.X - 1, tileLocation.Y));
            neighborCandidates.Add(new Point(tileLocation.X, tileLocation.Y + 1));
            neighborCandidates.Add(new Point(tileLocation.X, tileLocation.Y - 1));
            neighborCandidates.Add(new Point(tileLocation.X + 1, tileLocation.Y + 1));
            neighborCandidates.Add(new Point(tileLocation.X + 1, tileLocation.Y - 1));
            neighborCandidates.Add(new Point(tileLocation.X - 1, tileLocation.Y + 1));
            neighborCandidates.Add(new Point(tileLocation.X - 1, tileLocation.Y - 1));

            foreach (Point item in neighborCandidates)
            {
                if (DoesTileExist(item, dimension))
                {
                    neighbors.Add(item);
                }
            }

            return neighbors;
        }

        /// <summary>
        /// Determines if the specified location is actually a tile in the current map.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <returns></returns>
        public static bool DoesTileExist(Point tileLocation, int dimension)
        {
            return World.Data.World.Dimensions[dimension].DoesTileExist(tileLocation.X, tileLocation.Y);
        }
    }
}