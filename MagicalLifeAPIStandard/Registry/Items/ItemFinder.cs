using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.DataTypes.R;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util.Math;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System;
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
        /// Finds the item(s) closest to the <paramref name="mapLocation"/> that matches the <paramref name="itemID"/> that are not already reserved for a job.
        /// Returns null if no result found.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="mapLocation"></param>
        /// <returns>Returns the map location of the closest item of a specified spot.</returns>
        public static Point2D FindNearestUnreserved(int itemID, Point2D mapLocation, int dimension)
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
                        Tile tile = World.Data.World.GetTile(dimension, it.X, it.Y);
                        if (tile.Item != null && tile.Item.ReservedID == Guid.Empty)
                        {
                            allNear.Add(new Rectangle(it.X, it.Y, it.X, it.Y), it);
                        }
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

        /// <summary>
        /// Returns true if there exists a certain item that is unreserved. 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="dimension"></param>
        /// <param name="startingPoint"></param>
        /// <returns></returns>
        public static bool IsItemAvailible(int itemID, int dimension, Point2D startingPoint)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, startingPoint, dimension);

            if (nearestChunks != null && nearestChunks.Count > 0)
            {
                RTree<Point2D> allNear = new RTree<Point2D>();

                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    //0-15
                    chunk = World.Data.World.GetChunk(dimension, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemID];
                    List<Point2D> result = items.Intersects(new Rectangle(WorldUtil.GetFirstTileLocation(chunk.ChunkLocation), WorldUtil.GetLastTileLocation(chunk.ChunkLocation)));

                    foreach (Point2D it in result)
                    {
                        Tile tile = World.Data.World.GetTile(dimension, it.X, it.Y);
                        if (tile.Item != null && tile.Item.ReservedID == Guid.Empty)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Locates a certain quantity of a requested item that isn't reserved, and returns their locations.
        /// Returns null if not enough items were found to satisfy the request.
        /// </summary>
        /// <returns></returns>
        public static List<Point2D> LocateUnreservedQuantityOfItem(int itemID, int quantityDesired, Point2D startingPoint, int dimension)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, startingPoint, dimension);

            int quantityFound = 0;
            List<Point2D> locations = new List<Point2D>();

            if (nearestChunks != null)
            {
                List<Point2D> allNear = new List<Point2D>();

                Chunk chunk;
                List<Point2D> allResults = new List<Point2D>();//Holds all found item locations.
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(dimension, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemID];
                    List<Point2D> result = items.Intersects(new Rectangle(WorldUtil.GetFirstTileLocation(chunk.ChunkLocation), WorldUtil.GetLastTileLocation(chunk.ChunkLocation)));
                    allResults.AddRange(result);
                }

                //Orders all items found by their proximity to the starting location.
                Geometry.OrderPointsByProximity(startingPoint, allResults);

                int length = allResults.Count;
                for (int i = 0; i < length && quantityFound < quantityDesired; i++)
                {
                    Point2D item = allResults[i];
                    Tile containing = World.Data.World.GetTile(dimension, item.X, item.Y);
                    if (containing.Item.ReservedID.Equals(Guid.Empty))
                    {
                        locations.Add(item);
                        quantityFound += containing.Item.CurrentlyStacked;
                    }
                }
            }

            if (quantityFound >= quantityDesired)
            {
                return locations;
            }
            else
            {
                return null;
            }
        }
    }
}