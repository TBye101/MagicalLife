using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeGUIWindows.Rendering;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagicalLifeGUIWindows.GUI.Reusable.API
{
    public class RenderableString : AbstractGUIRenderable
    {
        public SpriteFont Font { get; private set; }

        public string Text { get; private set; }

        public RenderableString(SpriteFont font, string text)
        {
            this.Font = font;
            this.Text = text;
        }

        public override void Render(SpriteBatch spBatch, Rectangle targetLocation)
        {
            SimpleTextRenderer.DrawString(this.Font, this.Text, targetLocation, SimpleTextRenderer.Alignment.Left, RenderingPipe.colorMask, ref spBatch);
        }
    }
}
