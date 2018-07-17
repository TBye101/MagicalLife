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
        protected static readonly string[] textures = new string[9]
        {
            "Grass",
            "DirtGrassTrans1",
            "DirtGrassTrans3",
            "DirtGrassTrans6",
            "DirtGrassTrans8",
            "DirtGrassTrans2",
            "DirtGrassTrans4",
            "DirtGrassTrans5",
            "DirtGrassTrans7"
        };

        public ConnectedGrass() : base(textures)
        {
        }

        protected override int GetTexture(TileState[] states)
        {
            if (this.UseTrans2(states))
            {
                return 5;
            }
            if (this.UseTrans3(states))
            {
                return 2;
            }
            if (this.UseTrans4(states))
            {
                return 6;
            }
            if (this.UseTrans5(states))
            {
                return 7;
            }

            return 0;
        }

        private bool UseTrans3(TileState[] states)
        {
            return states[0] == TileState.Identical && states[6] == TileState.Identical && states[3] == TileState.Compatible && states[5] == TileState.Compatible;
        }

        private bool UseTrans2(TileState[] states)
        {
            return states[6] == TileState.Compatible && states[3] == TileState.Identical && states[4] == TileState.Identical;
        }

        private bool UseTrans4(TileState[] states)
        {
            return states[4] == TileState.Compatible && states[1] == TileState.Identical && states[6] == TileState.Identical;
        }

        private bool UseTrans5(TileState[] states)
        {
            return states[1] == TileState.Identical && states[6] == TileState.Identical && states[3] == TileState.Compatible;
        }

        private bool UseTrans7(TileState[] states)
        {
            return states[1] == TileState.Compatible && states[3] == TileState.Identical && states[4] == TileState.Identical;
        }
    }
}