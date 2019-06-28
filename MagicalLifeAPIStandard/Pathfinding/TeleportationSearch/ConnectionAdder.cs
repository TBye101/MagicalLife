using MagicalLifeAPI.Components.MAP_GUI;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to add connections to the graph.
    /// </summary>
    public class ConnectionAdder
    {
        private readonly List<Point3D> Neighbors;
        private readonly List<Point3D> ExtraConnections;

        public ConnectionAdder()
        {
            this.Neighbors = new List<Point3D>();
            this.ExtraConnections = new List<Point3D>();
        }

        public void AddConnections(Point3D location, NodeStorage storage)
        {
            this.DiagnolFavorNeighboringTiles(location, location.DimensionID);
            Dimension dim = World.Data.World.Dimensions[location.DimensionID];

            Tile targetLocation = dim[location.X, location.Y];

            if (targetLocation.IsWalkable)
            {
                foreach (Point3D item in this.Neighbors)
                {
                    Tile t = dim[item.X, item.Y];
                    if (t.IsWalkable)
                    {
                        storage.AddConnection(location, item);
                    }
                }

                Tile tile = dim[location.X, location.Y];

                GameObject ceiling = tile.Ceiling;
                GameObject floor = tile.Floor;
                GameObject mainObject = tile.MainObject;

                this.ExtraConnections.Clear();
                if (ceiling != null)
                {
                    PortalComponent ceilingPortals = ceiling.GetComponent<PortalComponent>();

                    if (ceilingPortals != null)
                    {
                        this.ExtraConnections.AddRange(ceilingPortals.Connections);
                    }
                }

                if (floor != null)
                {
                    PortalComponent floorPortals = floor.GetComponent<PortalComponent>();
                    if (floorPortals != null)
                    {
                        this.ExtraConnections.AddRange(floorPortals.Connections);
                    }
                }

                if (mainObject != null)
                {
                    PortalComponent mainObjectPortals = mainObject.GetComponent<PortalComponent>();
                    if (mainObjectPortals != null)
                    {
                        this.ExtraConnections.AddRange(mainObjectPortals.Connections);
                    }
                }

                foreach (Point3D item in this.ExtraConnections)
                {
                    storage.AddConnection(location, item);
                }
            }
        }

        /// <summary>
        /// Gets all of the neighbors, but returns diagnol neighbors first.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        private void DiagnolFavorNeighboringTiles(Point3D tileLocation, Guid dimensionID)
        {
            this.Neighbors.Clear();
            this.Neighbors.Add(new Point3D(tileLocation.X + 1, tileLocation.Y + 1, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X + 1, tileLocation.Y - 1, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X - 1, tileLocation.Y + 1, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X - 1, tileLocation.Y - 1, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X + 1, tileLocation.Y, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X - 1, tileLocation.Y, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X, tileLocation.Y + 1, dimensionID));
            this.Neighbors.Add(new Point3D(tileLocation.X, tileLocation.Y - 1, dimensionID));

            for (int i = this.Neighbors.Count - 1; i > -1; i--)
            {
                if (!WorldUtil.DoesTileExist(this.Neighbors[i], dimensionID))
                {
                    this.Neighbors.RemoveAt(i);
                }
            }
        }
    }
}
