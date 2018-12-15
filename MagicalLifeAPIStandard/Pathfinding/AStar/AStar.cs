using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using RoyT.AStar;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding.AStar
{
    /// <summary>
    /// Uses an A* algorithm.
    /// </summary>
    public class AStar : IPathFinder
    {
        private Grid Grid;

        public void AddConnections(Point2D location)
        {
            this.Grid.UnblockCell(new Position(location.X, location.Y));
        }

        public List<PathLink> GetRoute(int dimension, Point2D origin, Point2D destination)
        {
            Position[] path = this.Grid.GetPath(new Position(origin.X, origin.Y), new Position(destination.X, destination.Y));
            List<PathLink> ret = new List<PathLink>();

            if (!World.Data.World.Dimensions[dimension][destination.X, destination.Y].IsWalkable)
            {
                throw new InvalidPathException();
            }

            if (path.Length < 1)
            {
                throw new InvalidPathException();
            }

            int i = 0;
            int length = path.Length - 1;
            while (i != length)
            {
                if (!World.Data.World.Dimensions[dimension][path[i].X, path[i].Y].IsWalkable)
                {
                    throw new InvalidPathException();
                }

                ret.Add(new PathLink(new Point2D(path[i].X, path[i].Y), new Point2D(path[i + 1].X, path[i + 1].Y)));
                i++;
            }

            return ret;
        }

        public void Initialize(Dimension dimension)
        {
            this.Grid = new Grid(dimension.Width * Chunk.Width, dimension.Height * Chunk.Height, 1);
            foreach (Tile item in dimension)
            {
                Position pos = new Position(item.MapLocation.X, item.MapLocation.Y);

                this.Grid.SetCellCost(pos, item.MovementCost);
                if (!item.IsWalkable)
                {
                    this.Grid.BlockCell(pos);
                    MasterLog.DebugWriteLine("Blocking tile: " + pos.ToString());
                }
            }
        }

        public bool IsRoutePossible(int dimension, Point2D origin, Point2D destination)
        {
            Position[] path = this.Grid.GetPath(new Position(origin.X, origin.Y), new Position(destination.X, destination.Y));

            if (!World.Data.World.Dimensions[dimension][destination.X, destination.Y].IsWalkable)
            {
                return false;
            }

            if (path.Length < 1)
            {
                return false;
            }

            int i = 0;
            int length = path.Length - 1;
            while (i != length)
            {
                if (!World.Data.World.Dimensions[dimension][path[i].X, path[i].Y].IsWalkable)
                {
                    return false;
                }

                i++;
            }

            return true;
        }

        public void RemoveConnections(Point2D location)
        {
            this.Grid.BlockCell(new Position(location.X, location.Y));
        }
    }
}