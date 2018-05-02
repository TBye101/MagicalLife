using MagicalLifeAPI.Universal;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// Any class that inherits from this has a texture.
    /// </summary>
    public class HasTexture : Unique
    {
        /// <summary>
        /// The index of the texture in our asset manager.
        /// </summary>
        public int TextureIndex { get; set; }

        public HasTexture(int textureIndex)
        {
            this.TextureIndex = textureIndex;
        }

        public HasTexture()
        {
        }
    }
}