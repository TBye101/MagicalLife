using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.Pathfinding.TeleportationSearch;
using MLAPI.World;
using MLAPI.World.Base;

namespace MLAPI.Pathfinding.AStar.Providers
{
    /// <summary>
    /// Provides access to worlds stored in the <see cref="World.Data.World"/>.
    /// </summary>
    public class StoredWorldProvider : IWorldProvider
    {
        public Tile GetTile(Point3D location)
        {
            return World.Data.World.GetTile(location);
        }
    }
}
