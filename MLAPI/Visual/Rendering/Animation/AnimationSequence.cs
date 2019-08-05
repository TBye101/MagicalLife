using MLAPI.Util.Reusable;
using ProtoBuf;

namespace MLAPI.Visual.Rendering.Animation
{
    /// <summary>
    /// Used to hold the order of an animation sequence.
    /// </summary>
    [ProtoContract]
    public class AnimationSequence
    {
        /// <summary>
        /// Holds a collection of numbers that specify what frame number is to be displayed next.
        /// </summary>
        [ProtoMember(1)]
        public int[] FrameOrder { get; private set; }

        /// <summary>
        /// The target FPS for this animation.
        /// </summary>
        [ProtoMember(2)]
        public int Fps { get; private set; }

        /// <summary>
        /// Used to determine when to change frames.
        /// </summary>
        [ProtoMember(3)]
        private TickTimer FrameTimer;

        [ProtoMember(4)]
        private int CurrentFrame;

        /// <param name="frameOrder">The order the frames should be played in.</param>
        /// <param name="fps">The target FPS for this animation.</param>
        public AnimationSequence(int[] frameOrder, int fps)
        {
            this.FrameOrder = frameOrder;
            this.Fps = fps;
            this.FrameTimer = new TickTimer(RenderInfo.GameFps / fps);
        }

        private AnimationSequence()
        {
            //Protobuf-net constructor
        }

        public void ResetToBeginning()
        {
            this.FrameTimer.Reset();
            this.CurrentFrame = 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="frame">The position within a sprite sheet that should be played next.</param>
        /// <returns>Returns true if the AnimationSequence has completed, and has been reset.</returns>
        public bool Tick(out int frame)
        {
            bool done = this.ShiftFrame();

            frame = this.FrameOrder[this.CurrentFrame];
            return done;
        }

        /// <summary>
        /// Changes which frame is being displayed.
        /// </summary>
        /// <returns>True if the sequence has finished.</returns>
        private bool ShiftFrame()
        {
            if (this.FrameTimer.Allow())
            {
                this.CurrentFrame++;

                if (this.CurrentFrame == this.FrameOrder.Length)
                {
                    this.ResetToBeginning();
                    return true;
                }
            }

            return false;
        }
    }
}