using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagicalLifeGUIWindows.GUI.Reusable.API
{
    /// <summary>
    /// Used by <see cref="ListBox"/> to render any possible item.
    /// </summary>
    public abstract class AbstractGUIRenderable
    {
        public abstract void Render(SpriteBatch spBatch, Rectangle containerBounds);
    }
}