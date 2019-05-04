using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeGUIWindows.GUI.In_Game_Escape_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class InGameEscapeMenuContainer : GuiContainer
    {
        public QuitButton Quit { get; private set; } = new QuitButton();

        public SaveButton Save { get; private set; } = new SaveButton();

        public BackButton Back { get; private set; } = new BackButton();

        public SettingsButton Settings { get; private set; } = new SettingsButton();

        public InGameEscapeMenuContainer() : base(TextureLoader.GUIMenuBackground, RenderInfo.FullScreenWindow, false)
        {
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Back);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}