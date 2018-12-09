using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeAPI.Util.Reusable
{
    /// <summary>
    /// An FPS counter.
    /// Borrowed courtesy of https://stackoverflow.com/a/20679895/9715095
    /// </summary>
    public class FrameCounter
    {
        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public static readonly int MAXIMUM_SAMPLES = 100;

        private readonly Queue<float> SampleBuffer = new Queue<float>();

        public bool Update(float deltaTime)
        {
            this.CurrentFramesPerSecond = 1.0f / deltaTime;

            this.SampleBuffer.Enqueue(this.CurrentFramesPerSecond);

            if (this.SampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                this.SampleBuffer.Dequeue();
                this.AverageFramesPerSecond = this.SampleBuffer.Average(i => i);
            }
            else
            {
                this.AverageFramesPerSecond = this.CurrentFramesPerSecond;
            }

            this.TotalFrames++;
            this.TotalSeconds += deltaTime;
            return true;
        }
    }
}