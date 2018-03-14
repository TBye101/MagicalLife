using MagicalLifeGUIWindows.GUI.MainMenu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    public class MainMenuContainer : GUIContainer
    {
        public MainMenuContainer(bool visible) : base("MenuBackground", GetDrawingBounds())
        {
            this.Visible = visible;
            this.Controls.Add(new NewGameButton());
            this.Controls.Add(new QuitButton());
        }

        public MainMenuContainer() : base()
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