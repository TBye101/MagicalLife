using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    public class World : Unique
    {
        /// <summary>
        /// A 3D array that holds every tile in the current world.
        /// </summary>
        public Tile[,,] Tiles { get; }
    }
}
