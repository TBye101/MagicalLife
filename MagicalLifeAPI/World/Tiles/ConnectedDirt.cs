using MagicalLifeAPI.Components.Tile.Renderable;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Tiles
{
    public class ConnectedDirt : AbstractConnectedTexture
    {
        protected static readonly string[] Textures =
            {
            "Dirt",
            "DirtGrassTrans2",
            "DirtGrassTrans4",
            "DirtGrassTrans5",
            "DirtGrassTrans7",
            "DirtGrassTrans9",
            "DirtGrassTrans10",
            "DirtGrassTrans11",
            "DirtGrassTrans12",
            "DirtGrassTrans1"
        };

        // |0|1 |2|
        // |3|Me|4|
        // |5|6 |7|
        // Compatible = 1,//The type of tile that we know how to blend with
        // Identical = 2,//Same type of tile as me
        // Incompatible = 3//Something else that I don't support

        public ConnectedDirt() : base(Textures)
        {
        }

        protected override int GetTexture(TileState[] states)
        {
            //if (this.UseTrans1(states))
            //{
            //    return 9;
            //}
            //if (this.UseTrans2(states))
            //{
            //    return 1;
            //}
            //if (this.UseTrans4(states))
            //{
            //    return 2;
            //}
            //if (this.UseTrans5(states))
            //{
            //    return 3;
            //}
            //if (this.UseTrans7(states))
            //{
            //    return 4;
            //}
            //if (this.UseTrans9(states))
            //{
            //    return 5;
            //}
            //if (this.UseTrans10(states))
            //{
            //    return 6;
            //}
            //if (this.UseTrans11(states))
            //{
            //    return 7;
            //}
            //if (this.UseTrans12(states))
            //{
            //    return 8;
            //}

            return 0;
        }

        private bool UseTrans1(TileState[] states)
        {
            return states[3] == TileState.Compatible && states[1] == TileState.Compatible && states[4] == TileState.Compatible && states[6] == TileState.Identical;
        }

        private bool UseTrans12(TileState[] states)
        {
            return states[3] == TileState.Compatible && states[5] == TileState.Compatible && states[6] == TileState.Compatible && this.NorthNotCompatible(states) && this.EastNotCompatible(states);
        }

        // |0|1 |2|
        // |3|Me|4|
        // |5|6 |7|

        /// <summary>
        /// If true, we should use the "DirtGrassTrans2" texture.
        /// </summary>
        /// <returns></returns>
        private bool UseTrans2(TileState[] states)
        {
            return this.NorthCompatible(states) && this.SouthNotCompatible(states) && states[3] != TileState.Compatible && states[4] != TileState.Compatible;
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans9" texture.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool UseTrans9(TileState[] states)
        {
            return states[3] == TileState.Compatible && states[0] == TileState.Compatible && states[1] == TileState.Compatible && this.EastNotCompatible(states) && this.SouthNotCompatible(states);
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans11" texture.
        /// </summary>
        /// <param name="tileStates"></param>
        /// <returns></returns>
        private bool UseTrans11(TileState[] states)
        {
            return states[6] == TileState.Compatible && states[7] == TileState.Compatible && states[4] == TileState.Compatible && this.EastNotCompatible(states) && this.NorthNotCompatible(states);
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans10" texture.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool UseTrans10(TileState[] states)
        {
            return states[1] == TileState.Compatible && states[2] == TileState.Compatible && states[4] == TileState.Compatible && states[3] != TileState.Compatible && states[5] != TileState.Compatible && states[6] != TileState.Compatible;
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans4" texture.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool UseTrans4(TileState[] states)
        {
            return this.WestCompatible(states) && this.EastNotCompatible(states) && states[1] != TileState.Compatible && states[6] != TileState.Compatible;
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans4" texture.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool UseTrans5(TileState[] states)
        {
            return this.EastCompatible(states) && this.WestNotCompatible(states) && states[1] != TileState.Compatible && states[6] != TileState.Compatible;
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans7" texture.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool UseTrans7(TileState[] states)
        {
            return this.SouthCompatible(states) && this.NorthNotCompatible(states) && states[3] != TileState.Compatible && states[4] != TileState.Compatible;
        }
    }
}