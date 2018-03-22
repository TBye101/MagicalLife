using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// Implemented by all GUI elements.
    /// </summary>
    public abstract class GUIElement : Unique
    {
        /// <summary>
        /// Constructs a new instance of the <see cref="GUIElement"/> class.
        /// </summary>
        /// <param name="image">The texture of this GUI element.</param>
        /// <param name="drawingBounds">The bounds for which to draw the texture on the screen at.</param>
        /// <param name="priority">Determines if this GUI element should have priority over other GUI elements when sorting through input.</param>
        public GUIElement(string image, Rectangle drawingBounds, int priority, string font)
        {
            this.DrawingBounds = drawingBounds;
            this.MouseBounds = new ClickBounds(drawingBounds, priority);
            BoundHandler.AddGUIElement(this);
            this.Image = AssetManager.Textures[AssetManager.GetTextureIndex(image)];

            if (font != null && font != string.Empty)
            {
                this.Font = Game1.AssetManager.Load<SpriteFont>(font);
            }
        }

        public GUIElement()
        {
        }

        /// <summary>
        /// The image of the button.
        /// </summary>
        public Texture2D Image { get; set; }

        /// <summary>
        /// The visibility of this button.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// The area on the screen to draw the button at.
        /// </summary>
        public Rectangle DrawingBounds { get; set; }

        /// <summary>
        /// The click bounds, which contains the <see cref="DrawingBounds"/>.
        /// </summary>
        public ClickBounds MouseBounds { get; set; }

        public SpriteFont Font { get; set; }

        public bool HasFocus { get; set; } = false;

        /// <summary>
        /// Called whenever this GUI element is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Click(MouseEventArgs e);

        /// <summary>
        /// Called whenever this GUI element is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void DoubleClick(MouseEventArgs e);
    }
}