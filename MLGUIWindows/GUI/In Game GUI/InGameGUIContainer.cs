using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLGUIWindows.GUI.In_Game_GUI.Buttons;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// The in game GUI container.
    /// </summary>
    public class InGameGuiContainer : GuiContainer
    {
        public MineActionButton MineActionButton { get; set; } = new MineActionButton();

        public TillDirtActionButton TillDirtActionButton { get; set; } = new TillDirtActionButton();

        public ChopActionButton ChopActionButton { get; set; } = new ChopActionButton();

        public InGameGuiContainer(bool visible)
            : base(TextureLoader.GuiMenuBackground, GetDrawingBounds(), false, true)
        {
            this.Visible = visible;
            this.Controls.Add(this.MineActionButton);
            this.Controls.Add(this.TillDirtActionButton);
            this.Controls.Add(this.ChopActionButton);
        }

        /// <summary>
        /// Returns the bounds of which this should be rendered at.
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetDrawingBounds()
        {
            int x = InGameGuiLayout.ContainerX;
            int y = InGameGuiLayout.ContainerY;
            int width = InGameGuiLayout.ContainerWidth;
            int height = InGameGuiLayout.ContainerHeight;

            return new Rectangle(x, y, width, height);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GuiMenuBackground;
        }
    }
}