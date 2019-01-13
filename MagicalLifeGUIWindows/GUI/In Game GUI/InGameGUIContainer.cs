using MagicalLifeAPI.Asset;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.In
{
    /// <summary>
    /// The in game GUI container.
    /// </summary>
    public class InGameGUIContainer : GUIContainer
    {
        public MineActionButton MineActionButton { get; set; } = new MineActionButton();

        public TillDirtActionButton TillDirtActionButton { get; set; } = new TillDirtActionButton();

        public ChopActionButton ChopActionButton { get; set; } = new ChopActionButton();

        public InGameGUIContainer(bool visible) : base(TextureLoader.GUIMenuBackground, GetDrawingBounds(), false)
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