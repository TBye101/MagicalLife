using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// A queue used to determine in what order things should be rendered.
    /// The higher the priority, the later the item is rendered.  
    /// The lower the priority, the more likely whatever is being rendered will be covered up by something with higher priority. 
    /// </summary>
    [ProtoContract]
    public class RenderQueue
    {
        /// <summary>
        /// The visuals in this render queue.
        /// </summary>
        [ProtoMember(1)]
        public SortedSet<AbstractVisual> Visuals { get; set; }

        public RenderQueue()
        {
            this.Visuals = new SortedSet<AbstractVisual>(new RenderQueueComparer());
        }
    }
}
