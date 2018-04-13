using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
