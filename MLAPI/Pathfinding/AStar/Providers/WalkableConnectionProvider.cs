using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.World;
using MLAPI.World.Base;

namespace MLAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// The default connection provider. Determines if tiles are connected by adjacency, ability to walk on, and PortalComponent connections.
    /// </summary>
    public class WalkableConnectionProvider : IConnectionProvider
    {
        public List<Point3D> CalculateConnections(Tile tile, IWorldProvider worldProvider, Point3D origin, Point3D destination)
        {
            Point3D location = tile.GetExactComponent<ComponentSelectable>().MapLocation;
            List<Point3D> neighbors = this.DiagnolFavorNeighboringTiles(location, location.DimensionId, worldProvider);

            if (tile.IsWalkable)
            {
                for (int i = neighbors.Count - 1; i > -1; i--)
                {
                    Tile t = worldProvider.GetTile(neighbors[i]);
                    if (!t.IsWalkable)
                    {
                        neighbors.RemoveAt(i);
                    }
                }

                GameObject ceiling = tile.Ceiling;
                GameObject floor = tile.Floor;
                GameObject mainObject = tile.MainObject;

                if (ceiling != null)
                {
                    PortalComponent ceilingPortals = ceiling.GetComponent<PortalComponent>();

                    if (ceilingPortals != null)
                    {
                        neighbors.AddRange(ceilingPortals.Connections);
                    }
                }

                if (floor != null)
                {
                    PortalComponent floorPortals = floor.GetComponent<PortalComponent>();
                    if (floorPortals != null)
                    {
                        neighbors.AddRange(floorPortals.Connections);
                    }
                }

                if (mainObject != null)
                {
                    PortalComponent mainObjectPortals = mainObject.GetComponent<PortalComponent>();
                    if (mainObjectPortals != null)
                    {
                        neighbors.AddRange(mainObjectPortals.Connections);
                    }
                }

                for (int i = neighbors.Count - 1; i > -1; i--)
                {
                    if (!worldProvider.DoesTileExist(neighbors[i]))
                    {
                        neighbors.RemoveAt(i);
                    }
                }

                return neighbors;
            }

            return new List<Point3D>();
        }

        /// <summary>
        /// Gets all of the neighbors, but returns diagnol neighbors first.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        private List<Point3D> DiagnolFavorNeighboringTiles(Point3D tileLocation, Guid dimensionId, IWorldProvider worldProvider)
        {
            List<Point3D> neighbors = new List<Point3D>(8)
            {
                new Point3D(tileLocation.X + 1, tileLocation.Y + 1, dimensionId),
                new Point3D(tileLocation.X + 1, tileLocation.Y - 1, dimensionId),
                new Point3D(tileLocation.X - 1, tileLocation.Y + 1, dimensionId),
                new Point3D(tileLocation.X - 1, tileLocation.Y - 1, dimensionId),
                new Point3D(tileLocation.X + 1, tileLocation.Y, dimensionId),
                new Point3D(tileLocation.X - 1, tileLocation.Y, dimensionId),
                new Point3D(tileLocation.X, tileLocation.Y + 1, dimensionId),
                new Point3D(tileLocation.X, tileLocation.Y - 1, dimensionId)
            };

            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                if (!worldProvider.DoesTileExist(neighbors[i]))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }
    }
}
