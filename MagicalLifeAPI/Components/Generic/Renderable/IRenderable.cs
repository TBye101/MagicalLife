namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Those who implement this interface have a component that is renderable onto the screen.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Returns the an instance of <see cref="AbstractRenderable"/> that knows what textureID to render.
        /// </summary>
        /// <returns></returns>
        AbstractRenderable GetRenderable();
    }
}