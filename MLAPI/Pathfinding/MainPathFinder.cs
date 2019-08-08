using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.Networking.Client;
using MLAPI.Networking.Messages;
using MLAPI.Pathfinding.AStar.Providers;
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
        public static readonly IConnectionProvider DefaultConnectionProvider = new WalkableConnectionProvider();
        public static readonly IWorldProvider DefaultWorldProvider = new StoredWorldProvider();

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
                Pathfinder = new DynamicAStar();
            }
            Pathfinder.Initialize(dimension);
        }

        public static void Block(Point3D tile)
        {
            Pathfinder.RemoveConnections(tile, DefaultConnectionProvider, DefaultWorldProvider);
        }

        public static void Block(Point3D tile, IConnectionProvider connectionProvider)
        {
            Pathfinder.RemoveConnections(tile, connectionProvider, DefaultWorldProvider);
        }

        public static void Block(Point3D tile, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            Pathfinder.RemoveConnections(tile, connectionProvider, worldProvider);
        }

        public static void UnBlock(Point3D tile)
        {
            Pathfinder.AddConnections(tile, DefaultConnectionProvider, DefaultWorldProvider);
        }

        public static void UnBlock(Point3D tile, IConnectionProvider connectionProvider)
        {
            Pathfinder.AddConnections(tile, connectionProvider, DefaultWorldProvider);
        }

        public static void UnBlock(Point3D tile, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            Pathfinder.AddConnections(tile, connectionProvider, worldProvider);
        }

        public static List<PathLink> GetRoute(Point3D start, Point3D end)
        {
            return Pathfinder.GetRoute(start, end, DefaultConnectionProvider, DefaultWorldProvider);
        }

        public static List<PathLink> GetRoute(Point3D start, Point3D end, IConnectionProvider connectionProvider)
        {
            return Pathfinder.GetRoute(start, end, connectionProvider, DefaultWorldProvider);
        }

        public static List<PathLink> GetRoute(Point3D start, Point3D end, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            return Pathfinder.GetRoute(start, end, connectionProvider, worldProvider);
        }

        public static bool IsRoutePossible(Point3D origin, Point3D destination)
        {
            return Pathfinder.IsRoutePossible(origin, destination, DefaultConnectionProvider, DefaultWorldProvider);
        }

        public static bool IsRoutePossible(Point3D origin, Point3D destination, IConnectionProvider connectionProvider)
        {
            return Pathfinder.IsRoutePossible(origin, destination, connectionProvider, DefaultWorldProvider);
        }

        public static bool IsRoutePossible(Point3D origin, Point3D destination, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            return Pathfinder.IsRoutePossible(origin, destination, connectionProvider, worldProvider);
        }

        /// <summary>
        /// Gives the living a route from start to end asynchronously. 
        /// </summary>
        public static void GiveRouteAsync(Living living, Point3D start, Point3D end)
        {
            GiveRouteAsync(living, start, end, DefaultConnectionProvider, DefaultWorldProvider);
        }

        /// <summary>
        /// Gives the living a route from start to end asynchronously. 
        /// </summary>
        public static void GiveRouteAsync(Living living, Point3D start, Point3D end, IConnectionProvider connectionProvider)
        {
            GiveRouteAsync(living, start, end, connectionProvider, DefaultWorldProvider);
        }

        /// <summary>
        /// Gives the living a route from start to end asynchronously. 
        /// </summary>
        public static void GiveRouteAsync(Living living, Point3D start, Point3D end, IConnectionProvider connectionProvider, IWorldProvider worldProvider)
        {
            Task.Run(() =>
            {
                List<PathLink> path = MainPathFinder.GetRoute(start, end, connectionProvider, worldProvider);
                ComponentMovement movementComponent = living.GetExactComponent<ComponentMovement>();
                Util.Extensions.EnqueueCollection(movementComponent.QueuedMovement, path);
                ClientSendRecieve.Send<RouteCreatedMessage>(new RouteCreatedMessage(path, living.Id, living.DimensionId));
            });
        }
    }
}