using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.World.Base;

namespace MLAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Implementations of this are used by the pathfinder to calculate connections between locations.
    /// </summary>
    public interface IConnectionProvider
    {
        /// <summary>
        /// Calculates the possible movement options from the tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        List<Point3D> CalculateConnections(Tile tile, IWorldProvider worldProvider, Point3D origin, Point3D destination);
    }
}
