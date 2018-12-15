using System;

namespace MagicalLifeAPI.Visual.Rendering.Renderer
{
    /// <summary>
    /// Holds a call to a rendering method in <see cref="MapBatch"/>, as well as holding its render layer.
    /// </summary>
    public struct RenderCallHolder : IEquatable<RenderCallHolder>
    {
        /// <summary>
        /// The layer at which something is to be rendered.
        /// </summary>
        public int RenderLayer { get; set; }

        /// <summary>
        /// The method stored that will render something.
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// An ID used to track the order in which calls are recieved.
        /// </summary>
        public int RenderCallID { get; set; }

        public RenderCallHolder(int renderLayer, Action action, int renderCallIID)
        {
            this.RenderLayer = renderLayer;
            this.Action = action;
            this.RenderCallID = renderCallIID;
        }

        public bool Equals(RenderCallHolder other)
        {
            return other.RenderLayer == this.RenderLayer && other.Action.Equals(this.Action);
        }
    }
}