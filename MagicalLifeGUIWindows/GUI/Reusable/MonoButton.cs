using MagicalLifeGUIWindows.Rendering;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public abstract class MonoButton : GUIElement
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="displayArea"></param>
        /// <param name="text"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        /// <param name="font"></param>
        protected MonoButton(string imageName, Rectangle displayArea, bool isContained, string text = "", string font = "MainMenuFont24x") : base(imageName, displayArea, int.MaxValue, isContained, font)
        {
            this.Text = text;
        }

        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            Rectangle location;
            int x = this.DrawingBounds.X + containerBounds.X;
            int y = this.DrawingBounds.Y + containerBounds.Y;
            location = new Rectangle(x, y, this.DrawingBounds.Width, this.DrawingBounds.Height);
            spBatch.Draw(this.Image, location, RenderingPipe.colorMask);
            SimpleTextRenderer.DrawString(this.Font, this.Text, location, Alignment.Center, RenderingPipe.colorMask, ref spBatch);
        }
    }
}