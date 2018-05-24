using MagicalLifeGUIWindows.GUI.MainMenu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    public class MainMenuContainer : GUIContainer
    {
        public MainMenuContainer(bool visible) : base("MenuBackground", RenderingPipe.FullScreenWindow)
        {
            this.Visible = visible;
            this.Controls.Add(new NewGameButton());
            this.Controls.Add(new HostGameButton());
            this.Controls.Add(new JoinGameButton());
            this.Controls.Add(new QuitButton());
        }

        public MainMenuContainer() : base()
        {
        }

        public override string GetTextureName()
        {
            return "MenuBackground";
        }
    }
}