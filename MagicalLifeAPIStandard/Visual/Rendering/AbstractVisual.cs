using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Visual.Rendering.AbstractVisuals;
using MagicalLifeGUIWindows.Rendering.Map;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Used to abstract away the complexities of animations and static textures.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(3, typeof(StaticTexture))]
    [ProtoInclude(4, typeof(AnimatedTexture))]
    [ProtoInclude(5, typeof(OffsetTexture))]
    public abstract class AbstractVisual
    {
        /// <summary>
        /// The priority of this <see cref="AbstractVisual"/> to be rendered.
        /// The higher the number, the closer to last it is rendered.
        /// The later a <see cref="AbstractVisual"/> is rendered, the more likely it will not be overlapped/cut off by anything else.
        /// Think of this like layers of a painting.
        /// </summary>
        [ProtoMember(1)]
        public int Priority { get; set; }

        /// <summary>
        /// The top left bound to render at that is relative to the tile position this AbstractVisual belongs to.
        /// </summary>
        [ProtoMember(2)]
        public Point2D RelativeTopLeft { get; set; }

        protected AbstractVisual(int priority)
        {
            this.Priority = priority;
        }

        protected AbstractVisual()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="bounds">The bounds to render the texture at.</param>
        public abstract void Render(MapBatch batch, Point2D ScreenTopLeft);
    }
}