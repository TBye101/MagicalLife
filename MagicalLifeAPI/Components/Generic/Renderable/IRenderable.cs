namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Those who implement this interface have a component that is renderable onto the screen.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Returns the an instance of <see cref="AbstractRenderable"/> that knows what to render, and when.
        /// </summary>
        /// <returns></returns>
        AbstractRenderable GetRenderable();
    }
}