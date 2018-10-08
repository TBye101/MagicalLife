using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Objects that implements this holds the rendering for many things.
    /// Ex: A tile.
    /// </summary>
    [ProtoContract]
    public interface IRenderContainer
    {
        /// <summary>
        /// Returns the an instance of <see cref="AbstractRenderable"/> that knows what to render, and when.
        /// </summary>
        /// <returns></returns>
        ComponentRenderer CompositeRenderer { get; set; }
    }
}