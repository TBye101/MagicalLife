using MagicalLifeAPI.Components.Tile.Renderable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tiles
{
    public class ConnectedGrass : AbstractConnectedTexture
    {
        protected static readonly string[] textures = new string[1]
        {
        "Grass"
        };

        public ConnectedGrass() : base(textures)
        {
        }

        protected override int GetTexture(TileState[] tileStates)
        {
            return 0;
        }
    }
}