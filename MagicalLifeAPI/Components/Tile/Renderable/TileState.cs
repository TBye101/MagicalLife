using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Tile.Renderable
{
    /// <summary>
    /// Used to keep track of the texture states of tiles.
    /// </summary>
    public enum TileState
    {
        Compatible = 0,//The type of tile that we know how to blend with
        Identical = 1,//Same type of tile as me
        Incompatible = 2,//Something else that I don't support
    }
}