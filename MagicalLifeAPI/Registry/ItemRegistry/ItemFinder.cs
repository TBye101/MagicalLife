using MagicalLifeAPI.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Registry.ItemRegistry
{
    /// <summary>
    /// This class finds items that match various search parameters.
    /// </summary>
    public static class ItemFinder//TODO: Rework this to be faster, possibly by writing my own R-tree/other data structure
    {
        /// <summary>
        /// Finds the item closest to the <paramref name="target"/> that matches the <paramref name="itemID"/>.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Point2D FindNearest(int itemID, Point2D target)
        {
            RBush.RBush<Point2D> containingChunks = ItemRegistry.Registry.ItemIDToChunk[itemID];

            containingChunks.Search();//Gets all items
        }
    }
}
