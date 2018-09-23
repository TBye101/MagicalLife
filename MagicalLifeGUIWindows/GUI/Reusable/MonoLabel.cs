using MagicalLifeGUIWindows.Rendering;
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
    public class MonoLabel : GUIElement
    {
        /// <summary>
        /// The text contained in this label box.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The text alignment of this <see cref="MonoLabel"/>.
        /// </summary>
        public Alignment TextAlignment { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="image"></param>
        /// <param name="font"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        public MonoLabel(Rectangle bounds, string image, bool isContained) : base(bounds, int.MinValue, isContained, "MainMenuFont12x")
        {
        }

        public MonoLabel() : base()
        {
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            //This is a label. Nothing happens when you click on it.
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            //This is a label. Nothing happens when you click on it.
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            int x = containerBounds.X + this.DrawingBounds.X;
            int y = containerBounds.Y + this.DrawingBounds.Y;
            int width = this.DrawingBounds.Width;
            int height = this.DrawingBounds.Height;

            Rectangle Bounds = new Rectangle(x, y, width, height);
            SimpleTextRenderer.DrawString(this.Font, this.Text, Bounds, this.TextAlignment, Color.White, ref spBatch);
        }
    }
}