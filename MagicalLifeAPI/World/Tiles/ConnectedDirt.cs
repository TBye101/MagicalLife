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
            "Grass",
            "DirtGrassTrans1",
            "DirtGrassTrans2",
            "DirtGrassTrans3",
            "DirtGrassTrans4",
            "DirtGrassTrans5",
            "DirtGrassTrans6",
            "DirtGrassTrans7",
            "DirtGrassTrans8",
            "DirtGrassTrans9",
            "DirtGrassTrans10",
            "DirtGrassTrans11",
            "DirtGrassTrans12" };

        // |0|1 |2|
        // |3|Me|4|
        // |5|6 |7|
        // Compatible = 1,//The type of tile that we know how to blend with
        // Identical = 2,//Same type of tile as me
        // Incompatible = 3//Something else that I don't support

        public ConnectedDirt() : base(Textures)
        {
        }

        protected override int GetTexture(TileState[] tileStates)
        {
            if (this.UseDirt(tileStates))
            {
                return 0;
            }
            if (this.UseTrans2(tileStates))
            {
                return 3;
            }
            if (this.UseTrans4(tileStates))
            {
                return 5;
            }
            if (this.UseTrans5(tileStates))
            {
                return 6;
            }
            if (this.UseTrans7(tileStates))
            {
                return 8;
            }

            return 0;
        }

        // |0|1 |2|
        // |3|Me|4|
        // |5|6 |7|
        /// <summary>
        /// If true, we should use the "Dirt" texture.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool UseDirt(TileState[] states)
        {
            return this.AllSidesCompatible(states) || this.AllSidesSame(states);
        }

        /// <summary>
        /// If true, we should use the "DirtGrassTrans2" texture.
        /// </summary>
        /// <returns></returns>
        private bool UseTrans2(TileState[] states)
        {
            return this.NorthCompatible(states) && this.SouthNotCompatible(states) && states[3] != TileState.Compatible && states[4] != TileState.Compatible;
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

        private bool AllSidesSame(TileState[] states)
        {
            bool column1 = states[0] == TileState.Identical && states[3] == TileState.Identical && states[5] == TileState.Identical;
            bool column2 = states[1] == TileState.Identical && states[6] == TileState.Identical;
            bool column3 = states[2] == TileState.Identical && states[4] == TileState.Identical && states[7] == TileState.Identical;

            return column1 && column2 && column3;
        }

        /// <summary>
        /// Returns true if all neighboring sides are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool AllSidesCompatible(TileState[] states)
        {
            return this.NorthCompatible(states) && this.SouthCompatible(states) && states[3] == TileState.Compatible && states[4] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states East of the tile are not compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool EastNotCompatible(TileState[] states)
        {
            return states[2] != TileState.Compatible && states[4] != TileState.Compatible && states[7] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states to the East of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool EastCompatible(TileState[] states)
        {
            return states[2] == TileState.Compatible && states[4] == TileState.Compatible && states[7] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states to the West of the tile are not compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool WestNotCompatible(TileState[] states)
        {
            return states[0] != TileState.Compatible && states[3] != TileState.Compatible && states[5] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states to the West of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool WestCompatible(TileState[] states)
        {
            return states[0] == TileState.Compatible && states[3] == TileState.Compatible && states[5] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring tiles North of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool NorthNotCompatible(TileState[] states)
        {
            return states[0] != TileState.Compatible && states[1] != TileState.Compatible && states[2] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states North of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool NorthCompatible(TileState[] states)
        {
            return states[0] == TileState.Compatible && states[1] == TileState.Compatible && states[2] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states South of the tile are not compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool SouthNotCompatible(TileState[] states)
        {
            return states[7] != TileState.Compatible && states[6] != TileState.Compatible && states[5] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states South of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private bool SouthCompatible(TileState[] states)
        {
            return states[5] == TileState.Compatible && states[6] == TileState.Compatible && states[7] == TileState.Compatible;
        }
    }
}