using MagicalLifeAPI.World.Base;
using System;

namespace MagicalLifeAPI.World
{
    public class TileEventArg : EventArgs
    {
        public Tile Tile { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TileEventArg"/> class.
        /// </summary>
        /// <param name="tile"></param>
        public TileEventArg(Tile tile)
        {
            this.Tile = tile;
        }
    }
}