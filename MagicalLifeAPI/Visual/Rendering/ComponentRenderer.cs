using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// A renderer that takes various visual pieces and renders them in a meaningful fashion.
    /// </summary>
    [ProtoContract]
    public class ComponentRenderer
    {
        [ProtoMember(1)]
        public RenderQueue RenderQueue { get; set; }

        public ComponentRenderer()
        {
            this.RenderQueue = new RenderQueue();
        }

        public void Render(SpriteBatch batch)
        {
            foreach (AbstractVisual item in this.RenderQueue.Visuals)
            {
                item.Render(batch, item.Bounds);
            }
        }
    }
}
