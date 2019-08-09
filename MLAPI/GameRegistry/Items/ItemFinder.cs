using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.Pathfinding;
using MLAPI.Util.Math;
using MLAPI.World;
using MLAPI.World.Base;
using MLAPI.World.Data;

namespace MLAPI.GameRegistry.Items
{
    /// <summary>
    /// This class finds items that match various search parameters.
    /// </summary>
    public static class ItemFinder
    {
        public static readonly float SearchDistance = 10000;

        /// <summary>
        /// Finds the item(s) closest to the <paramref name="mapLocation"/> that matches the <paramref name="itemId"/> that are not already reserved for a job.
        /// Returns null if no result found.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="mapLocation"></param>
        /// <returns>Returns the map location of the closest item of a specified spot.</returns>
        public static Point2D FindNearestUnreserved(int itemId, Point3D mapLocation)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemId, mapLocation);

            if (nearestChunks != null)
            {
                RTree<Point2D> allNear = new RTree<Point2D>();

                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(mapLocation.DimensionId, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemId];
                    List<Point2D> result = items.Intersects(new Rectangle(0, 0, Chunk.Width, Chunk.Height));

                    foreach (Point2D it in result)
                    {
                        Tile tile = World.Data.World.GetTile(mapLocation.DimensionId, it.X, it.Y);
                        Item tileItem = tile.MainObject as Item;
                        if (tileItem != null && tileItem.ReservedId == Guid.Empty)
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
        /// Finds the item(s) closest to the <paramref name="mapLocation"/> that matches the <paramref name="itemId"/>.
        /// Returns null if no result found.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="mapLocation"></param>
        /// <returns>Returns the map location of the closest item of a specified spot.</returns>
        public static Point2D FindNearestLocation(int itemId, Point3D mapLocation)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemId, mapLocation);

            if (nearestChunks != null)
            {
                RTree<Point2D> allNear = new RTree<Point2D>();

                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(mapLocation.DimensionId, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemId];
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
        /// <param name="itemId">The ID of the item in question.</param>
        /// <param name="mapLocation">The origin of the search in map locations.</param>
        /// <returns></returns>
        public static List<Point2D> FindNearestChunks(int itemId, Point3D mapLocation)
        {
            RTree<Point2D> containingChunks = World.Data.World.Dimensions[mapLocation.DimensionId].Items.ItemIdToChunk[itemId];

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
        /// Finds the nearest tile to a location without a main object in it.
        /// Returns null if all tiles have a main object in the entire map.
        /// Will not ever return the starting point specified.
        /// Ensures that there is a walkable path for the creature to get there from the specific map location to the returned location.
        /// </summary>
        /// <param name="mapLocation"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static Point3D FindMainObjectEmptyTile(Point3D mapLocation)
        {
            List<Point3D> tilesChecking = WorldUtil.GetAdjacentTiles(mapLocation);

            while (tilesChecking.Count > 0)
            {
                Point3D currentlyChecking = tilesChecking[0];
                Tile tile = World.Data.World.GetTile(mapLocation.DimensionId, currentlyChecking.X, currentlyChecking.Y);

                if (tile.MainObject == null && MainPathFinder.IsRoutePossible(mapLocation, Point3D.From2D(currentlyChecking, mapLocation.DimensionId)))
                {
                    //Found one!
                    return currentlyChecking;
                }

                //Add all neighbors of the tile since it wasn't free from items and resources.
                tilesChecking.AddRange(WorldUtil.GetAdjacentTiles(currentlyChecking));
                tilesChecking.RemoveAt(0);
            }

            //Didn't find anything
            return null;
        }

        /// <summary>
        /// Returns true if there exists a certain item that is unreserved.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="dimension"></param>
        /// <param name="startingPoint"></param>
        /// <returns></returns>
        public static bool IsItemAvailible(int itemId, Guid dimensionId, Point3D startingPoint)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemId, startingPoint);

            if (nearestChunks != null && nearestChunks.Count > 0)
            {
                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    //0-15
                    chunk = World.Data.World.GetChunk(dimensionId, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemId];
                    List<Point2D> result = items.Intersects(new Rectangle(WorldUtil.GetFirstTileLocation(chunk.ChunkLocation), WorldUtil.GetLastTileLocation(chunk.ChunkLocation)));

                    foreach (Point2D it in result)
                    {
                        Tile tile = World.Data.World.GetTile(startingPoint.DimensionId, it.X, it.Y);
                        Item tileItem = tile.MainObject as Item;
                        if (tileItem != null && tileItem.ReservedId == Guid.Empty)
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
        public static List<Point3D> LocateUnreservedQuantityOfItem(int itemId, int quantityDesired, Point3D startingPoint)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemId, startingPoint);

            int quantityFound = 0;
            List<Point2D> locations = new List<Point2D>();

            if (nearestChunks != null)
            {
                Chunk chunk;
                List<Point3D> allResults = new List<Point3D>();//Holds all found item locations.
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(startingPoint.DimensionId, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemId];
                    List<Point2D> result = items.Intersects(new Rectangle(WorldUtil.GetFirstTileLocation(chunk.ChunkLocation), WorldUtil.GetLastTileLocation(chunk.ChunkLocation)));
                    allResults.AddRange(Point3D.From2D(result, startingPoint.DimensionId));
                }

                //Orders all items found by their proximity to the starting location.
                Geometry.OrderPointsByProximity(startingPoint, allResults);

                int length = allResults.Count;
                for (int i = 0; i < length && quantityFound < quantityDesired; i++)
                {
                    Point2D item = allResults[i];
                    Tile containing = World.Data.World.GetTile(startingPoint.DimensionId, item.X, item.Y);
                    Item tileItem = containing.MainObject as Item;
                    if (tileItem.ReservedId.Equals(Guid.Empty))
                    {
                        locations.Add(item);
                        quantityFound += tileItem.CurrentlyStacked;
                    }
                }
            }

            if (quantityFound >= quantityDesired)
            {
                return Point3D.From2D(locations, startingPoint.DimensionId);
            }
            else
            {
                return null;
            }
        }
    }
}