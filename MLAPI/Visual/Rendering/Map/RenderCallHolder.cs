using System;

namespace MLAPI.Visual.Rendering.Map
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
        /// The number in line to be rendered.
        /// </summary>
        public int RenderCallId { get; set; }

        /// <summary>
        /// The method stored that will render something.
        /// </summary>
        public Action Action { get; set; }

        public RenderCallHolder(int renderLayer, Action action, int renderCallId)
        {
            this.RenderLayer = renderLayer;
            this.Action = action;
            this.RenderCallId = renderCallId;
        }

        public bool Equals(RenderCallHolder other)
        {
            return other.RenderLayer == this.RenderLayer && other.Action.Equals(this.Action);
        }
    }
}