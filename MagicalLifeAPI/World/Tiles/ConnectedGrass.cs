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
        protected static readonly string[] textures = new string[13]
        {
            "Grass",
            "DirtGrassTrans1",
            "DirtGrassTrans3",
            "DirtGrassTrans6",
            "DirtGrassTrans8",
            "DirtGrassTrans2",
            "DirtGrassTrans4",
            "DirtGrassTrans5",
            "DirtGrassTrans7",
            "DirtGrassTrans10",
            "DirtGrassTrans9",
            "DirtGrassTrans12",
            "DirtGrassTrans11"
        };

        public ConnectedGrass() : base(textures)
        {
        }

        protected override int GetTexture(TileState[] states)
        {
            //mostly dirt corners
            if (this.UseTrans10(states))
            {
                return 9;
            }
            if (this.UseTrans9(states))
            {
                return 10;
            }
            if (this.UseTrans12(states))
            {
                return 11;
            }
            if (this.UseTrans11(states))
            {
                return 12;
            }

            //Half-dirt
            if (this.UseTrans2(states))
            {
                return 5;
            }
            if (this.UseTrans4(states))
            {
                return 6;
            }
            if (this.UseTrans5(states))
            {
                return 7;
            }
            if (this.UseTrans7(states))
            {
                return 8;
            }

            //Mostly grass corners
            if (this.UseTrans3(states))
            {
                return 2;
            }
            if (this.UseTrans6(states))
            {
                return 3;
            }
            if (this.UseTrans8(states))
            {
                return 4;
            }

            return 0;
        }

        private bool UseTrans11(TileState[] states)
        {
            return states[6] == TileState.Identical && states[4] == TileState.Identical && states[5] == TileState.Compatible && states[2] == TileState.Compatible;
        }

        private bool UseTrans12(TileState[] states)
        {
            return states[3] == TileState.Identical && states[6] == TileState.Identical && states[1] == TileState.Compatible && states[4] == TileState.Compatible && states[7] == TileState.Compatible && states[5] != TileState.Compatible;
        }

        private bool UseTrans9(TileState[] states)
        {
            return states[3] == TileState.Identical && states[1] == TileState.Identical && states[4] == TileState.Compatible && states[6] == TileState.Compatible && states[5] == TileState.Compatible;
        }

        private bool UseTrans10(TileState[] states)
        {
            return states[1] == TileState.Identical && states[4] == TileState.Identical && states[0] == TileState.Compatible && states[7] == TileState.Compatible;
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

        private bool UseTrans6(TileState[] states)
        {
            return states[1] == TileState.Identical && states[4] == TileState.Identical && states[2] == TileState.Compatible;
        }

        private bool UseTrans7(TileState[] states)
        {
            return states[1] == TileState.Compatible && states[3] == TileState.Identical && states[4] == TileState.Identical;
        }

        private bool UseTrans8(TileState[] states)
        {
            return states[3] == TileState.Identical && states[1] == TileState.Identical && states[0] == TileState.Compatible;
        }
    }
}