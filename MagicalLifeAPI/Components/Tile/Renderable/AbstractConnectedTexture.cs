using MagicalLifeAPI.Asset;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Tile.Renderable
{
    /// <summary>
    /// All implementers hold rules to determine if a transition texture should be used, and if so, which one.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(2, typeof(ConnectedGrass))]
    public abstract class AbstractConnectedTexture
    {
        [ProtoMember(1)]
        protected int[] TextureIDs;

        /// <summary>
        /// The name of the texture that this <see cref="AbstractConnectedTexture"/> evaluates.
        /// </summary>
        /// <param name="textureName"></param>
        protected AbstractConnectedTexture(string[] textures)
        {
            int length = textures.Length;
            this.TextureIDs = new int[length];

            for (int i = 0; i < length; i++)
            {
                this.TextureIDs[i] = AssetManager.GetTextureIndex(textures[i]);
            }
        }

        /// <summary>
        /// Calculates the index to the string[] textures parameter that was passed into the constructor that is the correct texture to use.
        /// </summary>
        /// <param name="tileStates"></param>
        /// <returns></returns>
        // Converts the local texture index into a AssetManager one.
        public int GetTextureID(TileState[] tileStates)
        {
            return this.TextureIDs[this.GetTexture(tileStates)];
        }

        /// <summary>
        /// Calculates the index to the string[] textures parameter that was passed into the constructor that is the correct texture to use.
        /// Below is a table of what texture indexes represent which neighboring tile state.
        /// |0|1 |2|
        /// |3|Me|4|
        /// |5|6 |7|
        /// </summary>
        /// <param name="tileStates">An array of the states of neighboring tiles. Size: 8 (0-7).</param>
        /// <returns></returns>
        protected abstract int GetTexture(TileState[] tileStates);

        protected bool AllSidesSame(TileState[] states)
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
        protected bool AllSidesCompatible(TileState[] states)
        {
            return this.NorthCompatible(states) && this.SouthCompatible(states) && states[3] == TileState.Compatible && states[4] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states East of the tile are not compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool EastNotCompatible(TileState[] states)
        {
            return states[2] != TileState.Compatible && states[4] != TileState.Compatible && states[7] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states to the East of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool EastCompatible(TileState[] states)
        {
            return states[2] == TileState.Compatible && states[4] == TileState.Compatible && states[7] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states to the West of the tile are not compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool WestNotCompatible(TileState[] states)
        {
            return states[0] != TileState.Compatible && states[3] != TileState.Compatible && states[5] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states to the West of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool WestCompatible(TileState[] states)
        {
            return states[0] == TileState.Compatible && states[3] == TileState.Compatible && states[5] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring tiles North of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool NorthNotCompatible(TileState[] states)
        {
            return states[0] != TileState.Compatible && states[1] != TileState.Compatible && states[2] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states North of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool NorthCompatible(TileState[] states)
        {
            return states[0] == TileState.Compatible && states[1] == TileState.Compatible && states[2] == TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states South of the tile are not compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool SouthNotCompatible(TileState[] states)
        {
            return states[7] != TileState.Compatible && states[6] != TileState.Compatible && states[5] != TileState.Compatible;
        }

        /// <summary>
        /// Returns true if all neighboring states South of the tile are compatible.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        protected bool SouthCompatible(TileState[] states)
        {
            return states[5] == TileState.Compatible && states[6] == TileState.Compatible && states[7] == TileState.Compatible;
        }
    }
}