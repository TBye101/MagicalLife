using MagicalLifeAPI.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic
{
    /// <summary>
    /// Anything that implements this has a texture that can be rendered.
    /// </summary>
    public abstract class AbstractRenderable
    {
        /// <summary>
        /// Gets the current texture ID to render the object with.
        /// </summary>
        public abstract int TextureID { get; set; }

        /// <summary>
        /// Calculates the texture for the first time after world generation.
        /// </summary>
        public abstract void CalculateTexture(ProtoArray<World.Tile> tiles, Point2D myLocation);
    }
}