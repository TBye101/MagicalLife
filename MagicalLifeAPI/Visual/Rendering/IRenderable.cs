using MagicalLifeAPI.Components.Tile.Renderable;
using MagicalLifeAPI.DataTypes;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Anything that implements this has a texture that can be rendered.
    /// </summary>
    [ProtoContract]
    public interface IRenderable
    {
        /// <summary>
        /// Returns the an instance of <see cref="AbstractRenderable"/> that knows what to render, and when.
        /// </summary>
        /// <returns></returns>
        ComponentRenderer CompositeRenderer { get; set; }
    }
}