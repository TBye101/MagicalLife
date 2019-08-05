using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;

namespace MonoGUI.MonoGUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public class MonoButton : GuiElement
    {
        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; }

        protected int TextureId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="displayArea"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        /// <param name="font"></param>
        /// <param name="text"></param>
        protected MonoButton(string imageName, Rectangle displayArea, bool isContained, string font, string text = "") : base(displayArea, int.MaxValue, isContained, font)
        {
            this.Text = text;
            this.TextureId = AssetManager.GetTextureIndex(imageName);
        }

        protected MonoButton(string imageName, Rectangle displayArea, bool isContained, string text = "") : base(displayArea, int.MaxValue, isContained, TextureLoader.FontMainMenuFont12X)
        {
            this.Text = text;
            this.TextureId = AssetManager.GetTextureIndex(imageName);
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            Rectangle location;
            int x = this.DrawingBounds.X + containerBounds.X;
            int y = this.DrawingBounds.Y + containerBounds.Y;
            location = new Rectangle(x, y, this.DrawingBounds.Width, this.DrawingBounds.Height);
            spBatch.Draw(AssetManager.Textures[this.TextureId], location, Color.White);
            SimpleTextRenderer.DrawString(this.Font, this.Text, location, SimpleTextRenderer.Alignment.Center, Color.White, spBatch, RenderLayer.Gui);
        }
    }
}