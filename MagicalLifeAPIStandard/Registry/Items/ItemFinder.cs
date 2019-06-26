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
    public static class ItemFinder
    {
        public static readonly float SearchDistance = 10000;

        /// <summary>
        /// Finds the item(s) closest to the <paramref name="mapLocation"/> that matches the <paramref name="itemID"/> that are not already reserved for a job.
        /// Returns null if no result found.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="mapLocation"></param>
        /// <returns>Returns the map location of the closest item of a specified spot.</returns>
        public static Point2D FindNearestUnreserved(int itemID, Point3D mapLocation)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, mapLocation);

            if (nearestChunks != null)
            {
                RTree<Point2D> allNear = new RTree<Point2D>();

                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(mapLocation.DimensionID, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemID];
                    List<Point2D> result = items.Intersects(new Rectangle(0, 0, Chunk.Width, Chunk.Height));

                    foreach (Point2D it in result)
                    {
                        Tile tile = World.Data.World.GetTile(mapLocation.DimensionID, it.X, it.Y);
                        Item tileItem = tile.MainObject as Item;
                        if (tileItem != null && tileItem.ReservedID == Guid.Empty)
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
        public static Point2D FindNearestLocation(int itemID, Point3D mapLocation)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, mapLocation);

            if (nearestChunks != null)
            {
                RTree<Point2D> allNear = new RTree<Point2D>();

                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(mapLocation.DimensionID, item.X, item.Y);
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
        public static List<Point2D> FindNearestChunks(int itemID, Point3D mapLocation)
        {
            RTree<Point2D> containingChunks = World.Data.World.Dimensions[mapLocation.DimensionID].Items.ItemIDToChunk[itemID];

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
            List<Point3D> tilesChecking = WorldUtil.GetNeighboringTiles(mapLocation);

            while (tilesChecking.Count > 0)
            {
                Point3D currentlyChecking = tilesChecking[0];
                Tile tile = World.Data.World.GetTile(mapLocation.DimensionID, currentlyChecking.X, currentlyChecking.Y);

                if (tile.MainObject == null && MainPathFinder.IsRoutePossible(mapLocation, Point3D.From2D(currentlyChecking, mapLocation.DimensionID)))
                {
                    //Found one!
                    return currentlyChecking;
                }

                //Add all neighbors of the tile since it wasn't free from items and resources.
                tilesChecking.AddRange(WorldUtil.GetNeighboringTiles(currentlyChecking));
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
        public static bool IsItemAvailible(int itemID, Guid dimensionID, Point3D startingPoint)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, startingPoint);

            if (nearestChunks != null && nearestChunks.Count > 0)
            {
                Chunk chunk;
                foreach (Point2D item in nearestChunks)
                {
                    //0-15
                    chunk = World.Data.World.GetChunk(dimensionID, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemID];
                    List<Point2D> result = items.Intersects(new Rectangle(WorldUtil.GetFirstTileLocation(chunk.ChunkLocation), WorldUtil.GetLastTileLocation(chunk.ChunkLocation)));

                    foreach (Point2D it in result)
                    {
                        Tile tile = World.Data.World.GetTile(startingPoint.DimensionID, it.X, it.Y);
                        Item tileItem = tile.MainObject as Item;
                        if (tileItem != null && tileItem.ReservedID == Guid.Empty)
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
        public static List<Point3D> LocateUnreservedQuantityOfItem(int itemID, int quantityDesired, Point3D startingPoint)
        {
            List<Point2D> nearestChunks = FindNearestChunks(itemID, startingPoint);

            int quantityFound = 0;
            List<Point2D> locations = new List<Point2D>();

            if (nearestChunks != null)
            {
                Chunk chunk;
                List<Point3D> allResults = new List<Point3D>();//Holds all found item locations.
                foreach (Point2D item in nearestChunks)
                {
                    chunk = World.Data.World.GetChunk(startingPoint.DimensionID, item.X, item.Y);
                    RTree<Point2D> items = chunk.Items[itemID];
                    List<Point2D> result = items.Intersects(new Rectangle(WorldUtil.GetFirstTileLocation(chunk.ChunkLocation), WorldUtil.GetLastTileLocation(chunk.ChunkLocation)));
                    allResults.AddRange(Point3D.From2D(result, startingPoint.DimensionID));
                }

                //Orders all items found by their proximity to the starting location.
                Geometry.OrderPointsByProximity(startingPoint, allResults);

                int length = allResults.Count;
                for (int i = 0; i < length && quantityFound < quantityDesired; i++)
                {
                    Point2D item = allResults[i];
                    Tile containing = World.Data.World.GetTile(startingPoint.DimensionID, item.X, item.Y);
                    Item tileItem = containing.MainObject as Item;
                    if (tileItem.ReservedID.Equals(Guid.Empty))
                    {
                        locations.Add(item);
                        quantityFound += tileItem.CurrentlyStacked;
                    }
                }
            }

            if (quantityFound >= quantityDesired)
            {
                return Point3D.From2D(locations, startingPoint.DimensionID);
            }
            else
            {
                return null;
            }
        }
    }
}