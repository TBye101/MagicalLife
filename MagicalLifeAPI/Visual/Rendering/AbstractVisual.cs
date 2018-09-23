using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Used to abstract away the complexities of animations and static textures.
    /// </summary>
    public abstract class AbstractVisual
    {
        /// <summary>
        /// The priority of this <see cref="AbstractVisual"/> to be rendered. 
        /// The higher the number, the closer to last it is rendered.
        /// The later a <see cref="AbstractVisual"/> is rendered, the more likely it will not be overlapped/cut off by anything else.
        /// Think of this like layers of a painting.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// The bounds that this visual should be rendered at.
        /// </summary>
        public Rectangle Bounds { get; set; }

        public AbstractVisual(int priority)
        {
            this.Priority = priority;
        }

        public AbstractVisual()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="bounds">The bounds to render the texture at.</param>
        public abstract void Render(SpriteBatch batch, Rectangle bounds);
    }
}
