using MagicalLifeAPI.DataTypes;
using RTree;
using System.Collections.Generic;

namespace MagicalLifeAPI.Registry.ItemRegistry
{
    /// <summary>
    /// This class finds items that match various search parameters.
    /// </summary>
    public static class ItemFinder//TODO: Rework this to be faster, possibly by writing my own R-tree/other data structure
    {
        public static float SearchDistance = 10000;

        /// <summary>
        /// Finds the item closest to the <paramref name="target"/> that matches the <paramref name="itemID"/>.
        /// Returns null if no result found.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Point2D FindNearest(int itemID, Point2D target)
        {
            RTree<Point2D> containingChunks = ItemRegistry.Registry.ItemIDToChunk[itemID];

            List<Point2D> result = containingChunks.Nearest(new RPoint(target.X, target.Y), SearchDistance);

            if (result.Count == 0)
            {
                return null;//No result found.
            }
            else
            {
                return result[0];//Hopefully these are sorted from closest to furthest.
            }
        }
    }
}