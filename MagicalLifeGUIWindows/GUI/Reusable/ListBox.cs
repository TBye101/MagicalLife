using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable.API;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;
using System;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// Used to display a list of strings.
    /// </summary>
    public class ListBox : GUIElement, IScrollable
    {
        private int ItemBackgroundTexture { get; set; }

        /// <summary>
        /// The items that are displayed in this <see cref="ListBox"/>.
        /// </summary>
        public List<AbstractGUIRenderable> Items { get; set; }

        /// <summary>
        /// Width and height of an item display.
        /// </summary>
        private Point ItemDisplayBounds { get; set; }

        /// <summary>
        /// How many items should be displayed at any given time.
        /// </summary>
        private int ItemRenderCount { get; set; }

        /// <summary>
        /// The index of the first item in <see cref="this.Items"/> that is being displayed.
        /// </summary>
        private int FirstItemIndex { get; set; }

        /// <summary>
        /// Raised whenever there is a click in this <see cref="ListBox"/>, and has a parameter of what the index of the item that was clicked on is.
        /// </summary>
        public event EventHandler<int> ItemClick;

        /// <summary>
        /// Raised whenever there is a double click in this <see cref="ListBox"/>, and has a parameter of what the index of the item that was double clicked on is.
        /// </summary>
        public event EventHandler<int> ItemDoubleClick;

        /// <param name="itemRenderCount">How many items should be displayed at any given time.</param>
        /// <param name="items">The items that will be displayed.</param>
        public ListBox(Rectangle drawingBounds, int priority, bool isContained, string font, int itemRenderCount, List<AbstractGUIRenderable> items) : base(drawingBounds, priority, isContained, font)
        {
            this.ItemBackgroundTexture = AssetManager.GetTextureIndex("InputBox100x50");
            this.ItemRenderCount = itemRenderCount;
            this.Items = items;
            this.ItemDisplayBounds = this.CalculateItemBounds();
        }

        /// <summary>
        /// Calculates the height and width of each item to be displayed in this <see cref="ListBox"/>.
        /// </summary>
        /// <returns></returns>
        private Point CalculateItemBounds()
        {
            int width = this.DrawingBounds.Width;
            int height = this.DrawingBounds.Height / this.ItemRenderCount;

            return new Point(width, height);
        }

        public override void Click(MouseEventArgs e, GUIContainer container)
        {
            int indexClicked = ((e.Position.Y + container.DrawingBounds.Y) / this.ItemDisplayBounds.Y) - 1;
            this.ItemClickHandler(indexClicked);
        }

        public override void DoubleClick(MouseEventArgs e, GUIContainer container)
        {
            int indexDoubleClicked = ((e.Position.Y + container.DrawingBounds.Y) / this.ItemDisplayBounds.Y) - 1;
            this.ItemDoubleClickHandler(indexDoubleClicked);
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            int x = containerBounds.X + this.DrawingBounds.X;
            int y = containerBounds.Y + this.DrawingBounds.Y;

            int length;

            //How many items to display in our given bounds
            if (this.ItemRenderCount <= this.Items.Count)
            {
                length = this.ItemRenderCount;
            }
            else
            {
                length = this.Items.Count;
            }

            //Display each item
            for (int i = 0; i < this.ItemRenderCount; i++)
            {
                //Draw the background
                spBatch.Draw(AssetManager.Textures[this.ItemBackgroundTexture], new Rectangle(new Point(x, y), this.ItemDisplayBounds), RenderingPipe.colorMask);

                //Have the item draw itself
                this.Items[this.FirstItemIndex + i].Render(spBatch, containerBounds);
            }
        }

        public void Forward()
        {
            //Forward is in this case down

            if (this.ItemRenderCount + this.FirstItemIndex < this.Items.Count - 1)
            {
                this.FirstItemIndex++;
            }
        }

        public void Backwards()
        {
            //Backwards is in this case up

            if (this.FirstItemIndex > 0)
            {
                this.FirstItemIndex--;
            }
        }

        /// <summary>
        /// Raises the dimension added event.
        /// </summary>
        /// <param name="e"></param>
        private void ItemClickHandler(int e)
        {
            this.ItemClick?.Invoke(this, e);
        }

        private void ItemDoubleClickHandler(int e)
        {
            this.ItemDoubleClick?.Invoke(this, e);
        }
    }
}