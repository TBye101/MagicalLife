using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Visual.Rendering.Animation
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
        public int[] FrameOrder;

        public AnimationSequence(int[] frameOrder)
        {
            this.FrameOrder = frameOrder;
        }
    }
}
