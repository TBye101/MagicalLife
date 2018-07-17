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

        #region Dirt

        private static readonly int Dirt_1 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 1, 1, 1, 1, 1
            });

        private static readonly int Dirt_2 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 2, 2, 2, 2, 2, 2
            });

        private static readonly int Dirt_3 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 3, 3, 3, 3, 3, 3, 3
            });

        #endregion Dirt

        #region DirtGrassTrans2

        private static readonly int Trans2_1 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 2, 2, 2
            });

        private static readonly int Trans2_2 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 3, 3, 3
            });

        private static readonly int Trans2_3 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 2, 2, 3
            });

        private static readonly int Trans2_4 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 2, 3, 2
            });

        private static readonly int Trans2_5 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 3, 2, 2
            });

        private static readonly int Trans2_6 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 3, 2, 3
            });

        private static readonly int Trans2_7 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 3, 3, 2
            });

        private static readonly int Trans2_8 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 1, 1, 2, 2, 2, 3, 3
            });

        #endregion DirtGrassTrans2

        #region DirtGrassTrans4

        private static readonly int Trans4_1 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 2, 1, 2, 1, 2, 2
            });

        private static readonly int Trans4_2 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 3, 1, 3, 1, 2, 3
            });

        private static readonly int Trans4_3 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 3, 1, 2, 1, 2, 2
            });

        private static readonly int Trans4_4 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 2, 1, 3, 1, 2, 2
            });

        private static readonly int Trans4_5 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 2, 1, 2, 1, 2, 3
            });

        private static readonly int Trans4_6 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 3, 1, 3, 1, 2, 2
            });

        private static readonly int Trans4_7 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 2, 1, 3, 1, 2, 3
            });

        private static readonly int Trans4_8 = HashUtil.HashNumericArray(
            new int[8]
            {
                1, 2, 3, 1, 2, 1, 2, 3
            });

        #endregion DirtGrassTrans4

        #region DirtGrassTrans5

        private static readonly int Trans5_1 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 1, 2, 1, 2, 2, 1
            });

        private static readonly int Trans5_2 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 2, 1, 3, 1, 3, 2, 1
            });

        private static readonly int Trans5_3 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 2, 1, 2, 1, 2, 2, 1
            });

        private static readonly int Trans5_4 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 1, 3, 1, 2, 2, 1
            });

        private static readonly int Trans5_5 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 1, 2, 1, 3, 2, 1
            });

        private static readonly int Trans5_6 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 2, 1, 3, 1, 2, 2, 1
            });

        private static readonly int Trans5_7 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 2, 1, 2, 1, 3, 2, 1
            });

        private static readonly int Trans5_8 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 1, 3, 1, 3, 2, 1
            });

        #endregion DirtGrassTrans5

        #region DirtGrassTrans7

        private static readonly int Trans7_1 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 2, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_2 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 2, 2, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_3 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 3, 2, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_4 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 2, 3, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_5 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 3, 2, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_6 = HashUtil.HashNumericArray(
            new int[8]
            {
                2, 3, 3, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_7 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 2, 3, 2, 2, 1, 1, 1
            });

        private static readonly int Trans7_8 = HashUtil.HashNumericArray(
            new int[8]
            {
                3, 3, 3, 2, 2, 1, 1, 1
            });

        #endregion DirtGrassTrans7

        protected static readonly Dictionary<int, int> HashToTexture = ConnectedDirt.Populate();

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
            int currentState = HashUtil.HashNumericArray(tileStates.Cast<int>().ToArray<int>());

            MasterLog.DebugWriteLine("Search key: " + currentState.ToString());
            bool success = ConnectedDirt.HashToTexture.TryGetValue(currentState, out int value);

            if (success)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        private static Dictionary<int, int> Populate()
        {
            Dictionary<int, int> ret = new Dictionary<int, int>
            {
                { Dirt_1, 0 },
                { Dirt_2, 0 },
                { Dirt_3, 0 },

                { Trans2_1, 3 },
                { Trans2_2, 3 },
                { Trans2_3, 3 },
                { Trans2_4, 3 },
                { Trans2_5, 3 },
                { Trans2_6, 3 },
                { Trans2_7, 3 },
                { Trans2_8, 3 },

                { Trans5_1, 6 },
                { Trans5_2, 6 },
                { Trans5_3, 6 },
                { Trans5_4, 6 },
                { Trans5_5, 6 },
                { Trans5_6, 6 },
                { Trans5_7, 6 },
                { Trans5_8, 6 },

                { Trans7_1, 8 },
                { Trans7_2, 8 },
                { Trans7_3, 8 },
                { Trans7_4, 8 },
                { Trans7_5, 8 },
                { Trans7_6, 8 },
                { Trans7_7, 8 },
                { Trans7_8, 8 }
            };

            MasterLog.DebugWriteLine("Texture possibilities for dirt: ");
            foreach (KeyValuePair<int, int> item in ret)
            {
                MasterLog.DebugWriteLine("Key: " + item.Key.ToString() + ", Value: " + item.Value.ToString());
            }

            return ret;
        }
    }
}