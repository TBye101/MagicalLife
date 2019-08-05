using Microsoft.Xna.Framework;
using MLAPI.Asset;
using MLGUIWindows.GUI.In_Game_GUI.Buttons;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// The in game GUI container.
    /// </summary>
    public class InGameGUIContainer : GuiContainer
    {
        public MineActionButton MineActionButton { get; set; } = new MineActionButton();

        public TillDirtActionButton TillDirtActionButton { get; set; } = new TillDirtActionButton();

        public ChopActionButton ChopActionButton { get; set; } = new ChopActionButton();

        public InGameGUIContainer(bool visible)
            : base(TextureLoader.GUIMenuBackground, GetDrawingBounds(), false, true)
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
            int x = InGameGUILayout.ContainerX;
            int y = InGameGUILayout.ContainerY;
            int width = InGameGUILayout.ContainerWidth;
            int height = InGameGUILayout.ContainerHeight;

            return new Rectangle(x, y, width, height);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}