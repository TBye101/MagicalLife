using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Visual.Animation;
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
        private SpriteSheet AnimationFrames;//Find a way to render a specific texture from here

        //Find a way to easily kick off a animation sequence/organize sprites from sheet into animations



        public AnimatedTexture(int priority) : base(priority)
        {
        }

        public AnimatedTexture()
        {
        }

        public override void Render(SpriteBatch batch, Rectangle bounds)
        {
            throw new NotImplementedException();
        }
    }
}
