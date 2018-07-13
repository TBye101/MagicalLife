using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;
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
        /// Finds the item(s) closest to the <paramref name="mapLocation"/> that matches the <paramref name="itemID"/>.
        /// Returns null if no result found.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="mapLocation"></param>
        /// <returns>Returns the map location of the closest item of a specified spot.</returns>
        public static Point2D FindNearestLocation(int itemID, Point2D mapLocation, int dimension)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, mapLocation, dimension);

            RTree<Point2D> allNear = new RTree<Point2D>();

            Chunk chunk;
            foreach (Point2D item in nearestChunks)
            {
                chunk = World.Data.World.GetChunk(dimension, item.X, item.Y);
                RTree<Point2D> items = chunk.Items[itemID];
                List<Point2D> result = items.Intersects(new Rectangle(0, 0, Chunk.Width, Chunk.Height));

                foreach (Point2D it in result)
                {
                    allNear.Add(new Rectangle(it.X, it.Y, it.X, it.Y), it);
                }
            }

            List<Point2D> closest = allNear.Nearest(new RPoint2D(mapLocation.X, mapLocation.Y), SearchDistance);

            if (closest != null && closest.Count > 0)
            {
                return closest[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Finds the nearest chunk(s) that contains at least one of the item.
        /// </summary>
        /// <param name="itemID">The ID of the item in question.</param>
        /// <param name="mapLocation">The origin of the search in map locations.</param>
        /// <returns></returns>
        public static List<Point2D> FindNearestChunks(int itemID, Point2D mapLocation, int dimension)
        {
            RTree<Point2D> containingChunks = ItemRegistry.Registries[dimension].ItemIDToChunk[itemID];

            List<Point2D> result = containingChunks.Nearest(new RPoint2D(mapLocation.X / Chunk.Width, mapLocation.Y / Chunk.Height), SearchDistance);

            if (result.Count == 0)
            {
                return null;//No result found.
            }
            else
            {
                return result;//Hopefully these are sorted from closest to furthest.
            }
        }
    }
}