using MagicalLifeGUIWindows.GUI.New_World_Menu.Input_Boxes;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// The menu that pops up when the user creates a new world.
    /// </summary>
    public class NewWorldMenuContainer : GUIContainer
    {
        public NewWorldMenuContainer(bool visible) : base("MenuBackground", GetDrawingBounds())
        {
            this.Visible = visible;
            this.Controls.Add(new WorldWidthInputBox(false));
            this.Controls.Add(new WorldLengthInputBox(false));
            this.Controls.Add(new WorldDepthInputBox(false));
        }

        public NewWorldMenuContainer() : base()
        {
        }

        private static Rectangle GetDrawingBounds()
        {
            return new Rectangle(new Point(0, 0), new Point(MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Width, MagicalLifeSettings.Storage.MainWindow.Default.ScreenSize.Height));
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}