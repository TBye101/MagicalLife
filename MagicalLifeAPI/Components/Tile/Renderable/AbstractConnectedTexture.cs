using MagicalLifeAPI.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Tile.Renderable
{
    /// <summary>
    /// All implementers hold rules to determine if a transition texture should be used, and if so, which one.
    /// </summary>
    public abstract class AbstractConnectedTexture
    {
        protected int[] TextureIDs;

        /// <summary>
        /// The name of the texture that this <see cref="AbstractConnectedTexture"/> evaluates.
        /// </summary>
        /// <param name="textureName"></param>
        public AbstractConnectedTexture(string[] textures)
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
    }
}