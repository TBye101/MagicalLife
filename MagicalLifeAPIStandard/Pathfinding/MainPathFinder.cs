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
        /// Key: dimensionID
        /// Value: Pathfinder
        /// </summary>
        private static IPathFinder Pathfinder;

        public static void Initialize()
        {
            World.Data.World.DimensionAdded += World_DimensionAdded1;
        }

        private static void World_DimensionAdded1(object sender, Guid e)
        {
            PrepForDimension(World.Data.World.Dimensions[e]);
        }

        /// <summary>
        /// Creates a pathfinder for a dimension.
        /// </summary>
        /// <param name="dimension"></param>
        public static void PrepForDimension(Dimension dimension)
        {
            if (Pathfinder == null)
            {
                Pathfinder = new Search();
            }
            Pathfinder.Initialize(dimension);
        }

        public static void Block(Point3D tile)
        {
            Pathfinder.RemoveConnections(tile);
        }

        public static void UnBlock(Point3D tile)
        {
            Pathfinder.AddConnections(tile);
        }

        public static List<PathLink> GetRoute(Point3D start, Point3D end)
        {
            return Pathfinder.GetRoute(start, end);
        }

        public static bool IsRoutePossible(Point3D origin, Point3D destination)
        {
            return Pathfinder.IsRoutePossible(origin, destination);
        }
    }
}