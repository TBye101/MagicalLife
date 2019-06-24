using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Pathfinding.TeleportationSearch;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Handles who finds the path to destinations.
    /// </summary>
    public static class MainPathFinder
    {
        /// <summary>
        /// Pathfinders for all dimensions.
        /// </summary>
        private static List<IPathFinder> PathFinders = new List<IPathFinder>();

        public static void Initialize()
        {
            World.Data.World.DimensionAdded += World_DimensionAdded;
        }

        private static void World_DimensionAdded(object sender, int e)
        {
            PrepForDimension(World.Data.World.Dimensions[e]);
        }

        /// <summary>
        /// Creates a pathfinder for a dimension.
        /// </summary>
        /// <param name="dimension"></param>
        public static void PrepForDimension(Dimension dimension)
        {
            Search search = new Search();
            search.Initialize(dimension);
            PathFinders.Add(search);
        }

        public static void Block(Point2D tile, int dimension)
        {
            if (PathFinders.Count > 0)
            {
                Guid dimensionID = World.Data.World.Dimensions[dimension].ID;
                PathFinders[dimension].RemoveConnections(Point3D.From2D(tile, dimensionID));
            }
        }

        public static void UnBlock(Point2D tile, int dimension)
        {
            if (PathFinders.Count > 0)
            {
                Guid dimensionID = World.Data.World.Dimensions[dimension].ID;
                PathFinders[dimension].AddConnections(Point3D.From2D(tile, dimensionID), dimension);
            }
        }

        public static List<PathLink> GetRoute(int dimension, Point2D start, Point2D end)
        {
            Guid dimensionID = World.Data.World.Dimensions[dimension].ID;
            return PathFinders[dimension].GetRoute(Point3D.From2D(start, dimensionID), Point3D.From2D(end, dimensionID));
        }

        public static bool IsRoutePossible(int dimension, Point2D origin, Point2D destination)
        {
            Guid dimensionID = World.Data.World.Dimensions[dimension].ID;
            return PathFinders[dimension].IsRoutePossible(Point3D.From2D(origin, dimensionID), Point3D.From2D(destination, dimensionID));
        }
    }
}