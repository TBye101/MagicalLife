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
    public abstract class TextureCondition
    {
        public int TextureID { get; private set; }

        /// <summary>
        /// The name of the texture that this <see cref="TextureCondition"/> evaluates.
        /// </summary>
        /// <param name="textureName"></param>
        public TextureCondition(string textureName)
        {
            this.TextureID = AssetManager.GetTextureIndex(textureName);
        }

        /// <summary>
        /// Returns whether or not the texture this <see cref="TextureCondition"/> represents is applicable given the state of its neighbors.
        /// </summary>
        /// <param name="tileStates">An array of the states of neighboring tiles. Size: 8 (0-7).</param>
        /// <returns></returns>
        public abstract bool IsCorrectTexture(TileState[] tileStates);
    }
}