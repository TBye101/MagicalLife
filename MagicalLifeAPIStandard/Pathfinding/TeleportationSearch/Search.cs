using System;
using System.Collections.Generic;
using System.Text;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Data;

namespace MagicalLifeAPI.Pathfinding.TeleportationSearch
{
    public class Search : IPathFinder
    {
        private readonly List<SearchNode> Open = new List<SearchNode>();
        private readonly List<SearchNode> Closed = new List<SearchNode>();

        private bool DestinationReached = false;

        private readonly NodeStorage Storage = new NodeStorage();

        public Search()
        {
        }

        public void AddConnections(Point3D location)
        {
            throw new NotImplementedException();
        }

        public List<PathLink> GetRoute(int dimension, Point3D origin, Point3D destination)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            List<Dimension> dimensions = World.Data.World.Dimensions;
            
        }

        public bool IsRoutePossible(int dimension, Point3D origin, Point3D destination)
        {
            throw new NotImplementedException();
        }

        public void RemoveConnections(Point3D location)
        {
            this.Storage.RemoveAllConnections(location);
        }
    }
}
