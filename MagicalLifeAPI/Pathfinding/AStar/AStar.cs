using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World;
using Microsoft.Xna.Framework;
using RoyT.AStar;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding.AStar
{
    /// <summary>
    /// Uses an A* algorithm.
    /// </summary>
    public class AStar : IPathFinder
    {
        private Grid Grid;

        public void AddConnections(Point location)
        {
            this.Grid.UnblockCell(new Position(location.X, location.Y));
        }

        public List<PathLink> GetRoute(World.Data.World world, Living living, Point origin, Point destination)
        {
            MasterLog.DebugWriteLine("Finding route from: " + origin.ToString());
            MasterLog.DebugWriteLine("Finding route to: " + destination.ToString());
            Position[] path = this.Grid.GetPath(new Position(origin.X, origin.Y), new Position(destination.X, destination.Y));
            List<PathLink> ret = new List<PathLink>();

            if (!World.Data.World.Dimensions[living.Dimension][destination.X, destination.Y].IsWalkable)
            {
                throw new Exception("Destination not possible!");
            }

            if (path.Length < 1)
            {
                throw new Exception("Path not possible!");
            }

            int i = 0;
            int length = path.Length - 1;
            while (i != length)
            {
                if (!World.Data.World.Dimensions[living.Dimension][path[i].X, path[i].Y].IsWalkable)
                {
                    MasterLog.DebugWriteLine("Walking on unwalkable tile!");
                }

                ret.Add(new PathLink(new Point(path[i].X, path[i].Y), new Point(path[i + 1].X, path[i + 1].Y)));
                i++;
            }

            return ret;
        }

        public void Initialize()
        {
            ProtoArray<Tile> tiles = World.Data.World.MainWorld.Chunks;
            this.Grid = new Grid(tiles.Width, tiles.Height, 1);
            foreach (Tile item in tiles)
            {
                Position pos = new Position(item.Location.X, item.Location.Y);

                this.Grid.SetCellCost(pos, item.MovementCost);
                if (!item.IsWalkable)
                {
                    this.Grid.BlockCell(pos);
                    MasterLog.DebugWriteLine("Blocking tile: " + pos.ToString());
                }
            }
        }

        public void RemoveConnections(Point location)
        {
            this.Grid.BlockCell(new Position(location.X, location.Y));
        }
    }
}