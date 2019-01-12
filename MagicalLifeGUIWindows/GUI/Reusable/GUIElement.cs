using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// Implemented by all GUI elements.
    /// </summary>
    public abstract class GUIElement
    {
        /// <param name="drawingBounds">The bounds for which to draw the texture on the screen at.</param>
        /// <param name="priority">Determines if this GUI element should have priority over other GUI elements when sorting through input.</param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        protected GUIElement(Rectangle drawingBounds, int priority, bool isContained, string font)
        {
            this.DrawingBounds = drawingBounds;
            this.MouseBounds = new ClickBounds(drawingBounds, priority);

            if (!isContained)
            {
                BoundHandler.AddGUIElement(this);
            }

            if (font != null && font != string.Empty)
            {
                this.Font = Game1.AssetManager.Load<SpriteFont>(font);
            }
        }

        public GUIElement()
        {
        }

        /// <summary>
        /// Moves the click bounds of this GUI element by some amount.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveClickBounds(int xMove, int yMove)
        {
            Rectangle newPosition = new Rectangle(
                new Point((this.MouseBounds.Bounds.Location.X + xMove),
                (this.MouseBounds.Bounds.Location.Y + yMove)), this.MouseBounds.Bounds.Size);

            this.MouseBounds.Bounds = newPosition;
        }

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
        public abstract void Click(MouseEventArgs e, GUIContainer container);

        /// <summary>
        /// Called whenever this GUI element is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void DoubleClick(MouseEventArgs e, GUIContainer container);

        /// <summary>
        /// Called every frame that the element is visible.
        /// </summary>
        /// <param name="spBatch"></param>
        public abstract void Render(SpriteBatch spBatch, Rectangle containerBounds);
    }
}