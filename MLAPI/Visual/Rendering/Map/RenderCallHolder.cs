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
        /// The number in line to be rendered.
        /// </summary>
        public int RenderCallID { get; set; }

        /// <summary>
        /// The method stored that will render something.
        /// </summary>
        public Action Action { get; set; }

        public RenderCallHolder(int renderLayer, Action action, int renderCallID)
        {
            this.RenderLayer = renderLayer;
            this.Action = action;
            this.RenderCallID = renderCallID;
        }

        public bool Equals(RenderCallHolder other)
        {
            return other.RenderLayer == this.RenderLayer && other.Action.Equals(this.Action);
        }
    }
}