using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.Networking.Client;
using MLAPI.Networking.Messages;
using MLAPI.Pathfinding.TeleportationSearch;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.Pathfinding
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

        /// <summary>
        /// If true the path finder has been properly initialized.
        /// </summary>
        public static bool Initialized { get; set; } = false;

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
                Initialized = true;
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

        /// <summary>
        /// Gives the living a route from start to end asynchronously. 
        /// </summary>
        /// <param name="living"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void GiveRouteAsync(Living living, Point3D start, Point3D end)
        {
            Task routeTask = Task.Run(() =>
            {
                List<PathLink> path = MainPathFinder.GetRoute(start, end);
                ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();
                Util.Extensions.EnqueueCollection(movementComponent.QueuedMovement, path);
                ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(path, living.ID, living.DimensionID));
            });
        }
    }
}