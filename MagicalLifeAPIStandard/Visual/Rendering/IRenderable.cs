using MagicalLifeAPI.Components.Generic.Renderable;
using System.Collections.Generic;

namespace MagicalLifeAPI.Visual.Rendering
{
    /// <summary>
    /// Things that implement this are renderable.
    /// </summary>
    public interface IRenderable
    {
        /// <returns>Returns the visual layers to be rendered for this object.</returns>
        List<AbstractVisual> GetVisuals();
    }
}