using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.World.Base;

namespace MLAPI.Pathfinding.TeleportationSearch
{
    /// <summary>
    /// Used to provide the world to the pathfinding algorithm.
    /// </summary>
    public interface IWorldProvider
    {
        Tile GetTile(Point3D location);
    }
}
