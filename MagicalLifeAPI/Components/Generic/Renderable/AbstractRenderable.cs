using MagicalLifeAPI.Components.Tile.Renderable;
using MagicalLifeAPI.DataTypes;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Anything that implements this has a texture that can be rendered.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(2, typeof(StaticTexture))]
    [ProtoInclude(3, typeof(TransitionTextures))]
    public abstract class AbstractRenderable
    {
        /// <summary>
        /// Gets the current texture ID to render the object with.
        /// </summary>
        [ProtoMember(1)]
        public abstract int TextureID { get; set; }

        /// <summary>
        /// Calculates the texture for the first time after world generation.
        /// </summary>
        public abstract void CalculateTexture(ProtoArray<World.Base.Tile> tiles, Point2D myLocation);
    }
}