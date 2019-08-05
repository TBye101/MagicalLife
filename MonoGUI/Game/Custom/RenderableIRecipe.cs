using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MLAPI.Crafting;
using MLAPI.Filing.Logging;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MonoGUI.Game.Custom
{
    public class RenderableIRecipe : RenderableImage
    {
        private readonly IActionBarItem BarItem;

        public RenderableIRecipe(Rectangle bounds, int textureID, bool isContained, IActionBarItem actionBarItem) : base(bounds, textureID, isContained)
        {
            this.BarItem = actionBarItem;
            this.ClickEvent += this.RenderableIRecipe_ClickEvent;
            this.DoubleClickEvent += this.RenderableIRecipe_ClickEvent;
        }

        private void RenderableIRecipe_ClickEvent(object sender, ClickEventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                MasterLog.DebugWriteLine("Special click");
                this.BarItem.SpecialClicked();
            }
            else
            {
                this.BarItem.Clicked();
            }
        }

        public RenderableIRecipe(Rectangle bounds, string image, bool isContained, IActionBarItem actionBarItem) : base(bounds, image, isContained)
        {
            this.BarItem = actionBarItem;
            this.ClickEvent += this.RenderableIRecipe_ClickEvent;
            this.DoubleClickEvent += this.RenderableIRecipe_ClickEvent;
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            base.Render(spBatch, containerBounds);
        }
    }
}