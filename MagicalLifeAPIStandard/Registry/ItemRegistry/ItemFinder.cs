using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.DataTypes.R;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System.Collections.Generic;

namespace MagicalLifeAPI.Registry.ItemRegistry
{
    /// <summary>
    /// This class finds items that match various search parameters.
    /// </summary>
    public static class ItemFinder//TODO: Rework this to be faster, possibly by writing my own R-tree/other data structure
    {
        public static readonly float SearchDistance = 10000;

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

            if (nearestChunks != null)
            {
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

                List<Point2D> closest = allNear.Nearest(new Point(mapLocation.X, mapLocation.Y), SearchDistance);

                if (closest != null && closest.Count > 0)
                {
                    return closest[0];
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the nearest chunk(s) that contains at least one of the item.
        /// </summary>
        /// <param name="itemID">The ID of the item in question.</param>
        /// <param name="mapLocation">The origin of the search in map locations.</param>
        /// <returns></returns>
        public static List<Point2D> FindNearestChunks(int itemID, Point2D mapLocation, int dimension)
        {
            RTree<Point2D> containingChunks = World.Data.World.Dimensions[dimension].Items.ItemIDToChunk[itemID];

            List<Point2D> result = containingChunks.Nearest(new Point(mapLocation.X / Chunk.Width, mapLocation.Y / Chunk.Height), SearchDistance);

            if (result.Count == 0)
            {
                return null;//No result found.
            }
            else
            {
                return result;//Hopefully these are sorted from closest to furthest.
            }
        }

        /// <summary>
        /// Finds the nearest tile to a location without an item or a resource on it.
        /// Returns null if all tiles have an item or a resource in the entire map.
        /// Will not ever return the starting point specified.
        /// Ensures that there is a walkable path for the creature to get there from the specific map location to the returned location.
        /// </summary>
        /// <param name="mapLocation"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static Point2D FindItemEmptyTile(Point2D mapLocation, int dimension)
        {
            List<Point2D> tilesChecking = WorldUtil.GetNeighboringTiles(mapLocation, dimension);

            while (tilesChecking.Count > 0)
            {
                Point2D currentlyChecking = tilesChecking[0];
                Tile tile = World.Data.World.GetTile(dimension, currentlyChecking.X, currentlyChecking.Y);

                if (tile.Item == null
                    && tile.Resources == null
                    && MainPathFinder.IsRoutePossible(dimension, mapLocation, currentlyChecking))
                {
                    //Found one!
                    return currentlyChecking;
                }

                //Add all neighbors of the tile since it wasn't free from items and resources.
                tilesChecking.AddRange(WorldUtil.GetNeighboringTiles(currentlyChecking, dimension));
                tilesChecking.RemoveAt(0);
            }

            //Didn't find anything
            return null;
        }
    }
}