using MagicalLifeAPI.World.Base;
using System;

namespace MagicalLifeAPI.World
{
    public class TileEventArgs : EventArgs
    {
        public Tile Tile { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TileEventArg"/> class.
        /// </summary>
        /// <param name="tile"></param>
        public TileEventArgs(Tile tile)
        {
            this.Tile = tile;
        }
    }
}