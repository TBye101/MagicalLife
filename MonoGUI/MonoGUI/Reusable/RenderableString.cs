using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Visual.Rendering;

namespace MonoGUI.MonoGUI.Reusable
{
    /// <summary>
    /// A generic label class.
    /// </summary>
    public class RenderableString : GUIElement
    {
        public string Text { get; private set; }
        private SimpleTextRenderer.Alignment Alignment { get; }

        public RenderableString(SpriteFont font, string text, SimpleTextRenderer.Alignment alignment)
        {
            this.Font = font;
            this.Text = text;
            this.Alignment = alignment;
        }

        public override void Render(SpriteBatch spBatch, Rectangle targetLocation)
        {
            SimpleTextRenderer.DrawString(this.Font, this.Text, targetLocation, this.Alignment, Color.White, spBatch, RenderLayer.GUI);
        }
    }
}