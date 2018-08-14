using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagicalLifeGUIWindows.GUI
{
    /// <summary>
    /// Used by <see cref="ListBox"/> to render any possible item.
    /// </summary>
    public abstract class AbstractGUIRenderable
    {
        public abstract void Render(SpriteBatch spBatch, Rectangle containerBounds);
    }
}
