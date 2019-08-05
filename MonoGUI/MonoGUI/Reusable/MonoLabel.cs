using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;

namespace MonoGUI.MonoGUI.Reusable
{
    /// <summary>
    /// A generic label class.
    /// </summary>
    public class MonoLabel : GuiElement
    {
        /// <summary>
        /// The text contained in this label box.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The text alignment of this <see cref="MonoLabel"/>.
        /// </summary>
        public SimpleTextRenderer.Alignment TextAlignment { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="image"></param>
        /// <param name="font"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        public MonoLabel(Rectangle bounds, string image, bool isContained, string text) : base(bounds, int.MinValue, isContained, TextureLoader.FontMainMenuFont12X)
        {
            this.Text = text;
        }

        public MonoLabel()
        {
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            int x = containerBounds.X + this.DrawingBounds.X;
            int y = containerBounds.Y + this.DrawingBounds.Y;
            int width = this.DrawingBounds.Width;
            int height = this.DrawingBounds.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            if (width == 0 || height == 0)
            {
                throw new ArgumentException("Width or height cannot be 0");
            }

            if (this.Text != null)
            {
                SimpleTextRenderer.DrawString(this.Font, this.Text, bounds, this.TextAlignment, Color.White, spBatch, RenderLayer.Gui);
            }
        }
    }
}