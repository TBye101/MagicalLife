using MagicalLifeAPI.DataTypes;
using MagicalLifeGUIWindows.Rendering.Map;
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

        public void Render(MapBatch batch, Point2D ScreenTopLeft)
        {
            foreach (AbstractVisual item in this.RenderQueue.Visuals)
            {
                item.Render(batch, ScreenTopLeft);
            }
        }

        public void AddVisuals(List<AbstractVisual> visuals)
        {
            foreach (AbstractVisual item in visuals)
            {
                this.RenderQueue.Visuals.Add(item);
            }
        }
    }
}
