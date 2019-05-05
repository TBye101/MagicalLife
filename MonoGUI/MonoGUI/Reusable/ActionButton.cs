using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static MagicalLifeGUIWindows.Rendering.Text.SimpleTextRenderer;

namespace MonoGUI.MonoGUI.Reusable
{
    public class ActionButton : MonoButton
    {
        protected int SelectedTextureID { get; set; }

        public bool IsSelected { get; set; }

        protected int CorrectTextureID
        {
            get
            {
                return this.IsSelected ? this.SelectedTextureID : this.TextureID;
            }
        }

        protected ActionButton(string imageName, Microsoft.Xna.Framework.Rectangle displayArea, bool isContained, string font, string text = "") : base(imageName, displayArea, isContained, font, text)
        {
        }

        protected ActionButton(string imageName, Microsoft.Xna.Framework.Rectangle displayArea, bool isContained, string text = "") : base(imageName, displayArea, isContained, text)
        {
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            Rectangle location;
            int x = this.DrawingBounds.X + containerBounds.X;
            int y = this.DrawingBounds.Y + containerBounds.Y;
            location = new Rectangle(x, y, this.DrawingBounds.Width, this.DrawingBounds.Height);
            spBatch.Draw(AssetManager.Textures[CorrectTextureID], location, Color.White);
            SimpleTextRenderer.DrawString(this.Font, this.Text, location, Alignment.Center, Color.White, spBatch, RenderLayer.GUI);
        }
    }
}