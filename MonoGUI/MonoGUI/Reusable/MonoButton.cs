using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.GUI.Reusable.Event;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;
using System;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// A generic button class for use with the monogame framework, as well as the MagicalLifeGUI and API.
    /// </summary>
    public class MonoButton : GUIElement
    {
        /// <summary>
        /// The text to display on the monolith.
        /// </summary>
        public string Text { get; set; }

        protected int TextureID { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="displayArea"></param>
        /// <param name="text"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        /// <param name="font"></param>
        protected MonoButton(string imageName, Rectangle displayArea, bool isContained, string font, string text = "") : base(displayArea, int.MaxValue, isContained, font)
        {
            this.Text = text;
            this.TextureID = AssetManager.GetTextureIndex(imageName);
        }

        protected MonoButton(string imageName, Rectangle displayArea, bool isContained, string text = "") : base(displayArea, int.MaxValue, isContained, TextureLoader.FontMainMenuFont12x)
        {
            this.Text = text;
            this.TextureID = AssetManager.GetTextureIndex(imageName);
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            Rectangle location;
            int x = this.DrawingBounds.X + containerBounds.X;
            int y = this.DrawingBounds.Y + containerBounds.Y;
            location = new Rectangle(x, y, this.DrawingBounds.Width, this.DrawingBounds.Height);
            spBatch.Draw(AssetManager.Textures[this.TextureID], location, Color.White);
            SimpleTextRenderer.DrawString(this.Font, this.Text, location, Alignment.Center, Color.White, spBatch, RenderLayer.GUI);
        }
    }
}