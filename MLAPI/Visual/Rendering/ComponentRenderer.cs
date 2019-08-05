using System.Collections.Generic;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Visual.Rendering.Map;
using ProtoBuf;

namespace MLAPI.Visual.Rendering
{
    /// <summary>
    /// A renderer that takes various visual pieces and renders them in a meaningful fashion.
    /// </summary>
    [ProtoContract]
    public class ComponentRenderer : Component
    {
        [ProtoMember(1)]
        public List<AbstractVisual> RenderQueue { get; set; }

        public ComponentRenderer()
        {
            this.RenderQueue = new List<AbstractVisual>();
        }

        public void Render(MapBatch batch, Point2D screenTopLeft)
        {
            int length = this.RenderQueue.Count;
            for (int i = 0; i < length; i++)
            {
                AbstractVisual item = this.RenderQueue[i];
                item.Render(batch, screenTopLeft);
            }
        }

        public void AddVisuals(List<AbstractVisual> visuals)
        {
            foreach (AbstractVisual item in visuals)
            {
                this.AddVisual(item);
            }
        }

        public void AddVisual(AbstractVisual visual)
        {
            this.RenderQueue.Add(visual);
        }

        public void RemoveVisuals(List<AbstractVisual> visuals)
        {
            this.RenderQueue.RemoveAll(x => visuals.Contains(x));
        }
    }
}