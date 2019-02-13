using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic label class.
    /// </summary>
    public class RenderableString : GUIElement
    {
        public string Text { get; private set; }
        private Alignment Alignment { get; }

        public RenderableString(SpriteFont font, string text, Alignment alignment)
        {
            this.Font = font;
            this.Text = text;
            this.Alignment = alignment;
        }

        public override void Render(SpriteBatch spBatch, Rectangle targetLocation)
        {
            SimpleTextRenderer.DrawString(this.Font, this.Text, targetLocation, this.Alignment, Color.White, ref spBatch, RenderLayer.GUI);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            //Nothing to see here
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            //Nothing to see here
        }
    }
}