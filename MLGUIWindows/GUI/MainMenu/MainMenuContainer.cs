using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using MLGUIWindows.GUI.MainMenu.Buttons;
using MonoGUI.MonoGUI.Reusable;

namespace MLGUIWindows.GUI.MainMenu
{
    public class MainMenuContainer : GuiContainer
    {
        public MainMenuContainer(bool visible) : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Visible = visible;
            this.Controls.Add(new NewGameButton());
            this.Controls.Add(new LoadGameButton());
            this.Controls.Add(new JoinGameButton());
            this.Controls.Add(new SettingsButton());
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