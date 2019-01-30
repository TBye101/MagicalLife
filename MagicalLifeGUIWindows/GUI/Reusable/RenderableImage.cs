using MagicalLifeAPI.Asset;
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
    public class RenderableImage : GUIElement
    {
        private int TextureIndex;

        /// <param name="bounds"></param>
        /// <param name="image"></param>
        /// <param name="font"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        public RenderableImage(Rectangle bounds, string image, bool isContained) : base(bounds, int.MinValue, isContained, TextureLoader.FontMainMenuFont12x)
        {
            this.TextureIndex = AssetManager.NameToIndex[image];
        }

        public RenderableImage() : base()
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

            if (width == 0 || height == 0)
            {
                throw new InvalidDataException("Width or height cannot be 0");
            }

            spBatch.Draw(AssetManager.Textures[this.TextureIndex], Bounds, Color.White);
        }
    }
}