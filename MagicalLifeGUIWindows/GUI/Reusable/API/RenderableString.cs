using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Reusable.API
{
    /// <summary>
    /// Used to render a string from within a <see cref="ListBox"/>.
    /// </summary>
    public class RenderableString : GUIElement
    {
        public string Text { get; private set; }

        public RenderableString(SpriteFont font, string text)
        {
            this.Font = font;
            this.Text = text;
        }

        public override void Render(SpriteBatch spBatch, Rectangle targetLocation)
        {
            SimpleTextRenderer.DrawString(this.Font, this.Text, targetLocation, SimpleTextRenderer.Alignment.Center, Color.White, ref spBatch);
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