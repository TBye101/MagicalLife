using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.World;
using Microsoft.Xna.Framework;
using RoyT.AStar;

namespace MagicalLifeAPI.Pathfinding.AStar
{
    /// <summary>
    /// Uses an A* algorithm.
    /// </summary>
    public class AStar : IPathFinder
    {
        Grid Grid;

        public void AddConnections(Point location)
        {
            this.Grid.UnblockCell(new Position(location.X, location.Y));
        }

        public List<PathLink> GetRoute(World.World world, Living living, Point origin, Point destination)
        {
            Position[] path = this.Grid.GetPath(new Position(origin.X, origin.Y), new Position(destination.X, destination.Y));
            List<PathLink> ret = new List<PathLink>();

            int i = 0;
            int length = path.Length - 1;
            while (i != length)
            {
                ret.Add(new PathLink(new Point(path[i].X, path[i].Y), new Point(path[i + 1].X, path[i + 1].Y)));
                i++;
            }

            return ret; 
        }

        public void Initialize()
        {
            Tile[,] tiles = World.World.mainWorld.Tiles;
            this.Grid = new Grid(tiles.GetLength(0), tiles.GetLength(1), 1);

            foreach (Tile item in tiles)
            {
                Position pos = new Position(item.Location.X, item.Location.Y);
                if (!item.IsWalkable)
                {
                    this.Grid.BlockCell(pos);
                }

                this.Grid.SetCellCost(pos, item.MovementCost);
            }
        }

        public void RemoveConnections(Point location)
        {
            this.Grid.BlockCell(new Position(location.X, location.Y));
        }
    }
}
