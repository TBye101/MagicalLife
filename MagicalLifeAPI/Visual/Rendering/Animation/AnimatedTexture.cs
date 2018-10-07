using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Visual.Animation;
using MagicalLifeAPI.Visual.Rendering.Animation;
using MagicalLifeGUIWindows.Rendering.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Animations.
    /// </summary>
    [ProtoContract]
    public class AnimatedTexture : AbstractVisual
    {
        [ProtoMember(1)]
        private SpriteSheet AnimationFrames;//Find a way to render a specific texture from here

        /// <summary>
        /// The animation sequences that this animated texture can do.
        /// </summary>
        [ProtoMember(2)]
        private AnimationSequence[] Sequences;

        /// <summary>
        /// The index of the currently playing sequence in <see cref="Sequences"/>.
        /// </summary>
        [ProtoMember(3)]
        private int PlayingSequence = -1;

        public AnimatedTexture(int priority, AnimationSequence[] sequences) : base(priority)
        {
            this.Sequences = sequences;
        }

        public AnimatedTexture()
        {
        }

        public override void Render(MapBatch batch, Point2D ScreenTopLeft)
        {
            if (this.PlayingSequence != -1)
            {
                bool isDone = this.Sequences[this.PlayingSequence].Tick(out int frame);
                batch.Draw(this.AnimationFrames.Sprites, ScreenTopLeft, this.AnimationFrames.GetSection(frame));
            }
        }

        /// <summary>
        /// Starts playing the specified animation sequence. Stops and resets any previously playing sequences.
        /// </summary>
        /// <param name="SequenceID">The ID of the sequence to initiate.</param>
        public void StartSequence(int SequenceID)
        {
            if (this.PlayingSequence != -1)
            {
                this.Sequences[this.PlayingSequence].ResetToBeginning();
            }

            this.PlayingSequence = SequenceID;
        }
    }
}
