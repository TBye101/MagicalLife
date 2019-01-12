using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.GUI.MainMenu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    public class MainMenuContainer : GUIContainer
    {
        public MainMenuContainer(bool visible) : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Visible = visible;
            this.Controls.Add(new NewGameButton());
            this.Controls.Add(new LoadGameButton());
            this.Controls.Add(new JoinGameButton());
            this.Controls.Add(new QuitButton());
        }

        public MainMenuContainer() : base()
        {
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}