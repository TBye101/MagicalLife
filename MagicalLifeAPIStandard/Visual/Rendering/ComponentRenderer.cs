using MagicalLifeAPI.DataTypes;
using MagicalLifeGUIWindows.Rendering.Map;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// A renderer that takes various visual pieces and renders them in a meaningful fashion.
    /// </summary>
    [ProtoContract]
    public class ComponentRenderer
    {
        [ProtoMember(1)]
        public List<AbstractVisual> RenderQueue { get; set; }

        public ComponentRenderer()
        {
            this.RenderQueue = new List<AbstractVisual>();
        }

        public void Render(MapBatch batch, Point2D ScreenTopLeft)
        {
            int length = this.RenderQueue.Count;
            for (int i = 0; i < length; i++)
            {
                AbstractVisual item = this.RenderQueue[i];
                item.Render(batch, ScreenTopLeft);
            }
        }

        public void AddVisuals(List<AbstractVisual> visuals)
        {
            foreach (AbstractVisual item in visuals)
            {
                this.RenderQueue.Add(item);
            }
        }
    }
}